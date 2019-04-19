using GISCore.Business.Abstract;
using GISModel.DTO.Conta;
using GISModel.Entidades;
using GISModel.Enums;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace GISCore.Business.Concrete
{
    public class UsuarioBusiness : BaseBusiness<Usuario>, IUsuarioBusiness
    {

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        public Usuario ValidarCredenciais(AutenticacaoModel autenticacaoModel)
        {
            autenticacaoModel.Login = autenticacaoModel.Login.Trim();

            //Buscar usuário sem validar senha, para poder determinar se a validação da senha será com AD ou com a senha interna do GIS
            List<Usuario> lUsuarios = Consulta.Where(u => u.Login.Equals(autenticacaoModel.Login) ||
                                                          u.CPF.Equals(autenticacaoModel.Login) ||
                                                          u.Email.Equals(autenticacaoModel.Login)).ToList();

            if (lUsuarios.Count > 1 || lUsuarios.Count < 1)
            {
                throw new Exception("Não foi possível identificar o seu cadastro.");
            }
            else
            {

                if (lUsuarios[0].TipoDeAcesso.Equals(0))
                {
                    //Login, validando a senha no AD

                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["AD:DMZ"]))
                    {
                        //Chamar web service para validar a senha no AD
                        return null;
                    }
                    else
                    {

                        Empresa emp = EmpresaBusiness.Consulta.FirstOrDefault(a => string.IsNullOrEmpty(a.UsuarioExclusao) && a.IDEmpresa.Equals(lUsuarios[0].IDEmpresa));


                        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, emp.URL_AD))
                        {
                            if (pc.ValidateCredentials(autenticacaoModel.Login, autenticacaoModel.Senha))
                                return null;
                            else
                                throw new Exception("Login ou senha incorretos.");
                        }
                    }

                }
                else
                {
                    //Login, validando a senha interna do GIS
                    string IDUsuario = lUsuarios[0].IDUsuario;

                    string senhaTemp = CreateHashFromPassword(autenticacaoModel.Senha);
                    Usuario oUsuario = Consulta.FirstOrDefault(p => p.IDUsuario.Equals(IDUsuario) && p.Senha.Equals(senhaTemp));
                    if (oUsuario != null)
                    {
                        return oUsuario;
                    }
                    else
                    {
                        throw new Exception("Login ou senha incorretos.");
                    }
                }
            }

        }

        public byte[] RecuperarAvatar(string login)
        {
            try
            {
                WCF_Suporte.SuporteClient WCFSuporte = new WCF_Suporte.SuporteClient();
                return WCFSuporte.BuscarFotoPerfil(new WCF_Suporte.DadosUsuario()
                {
                    Login = login
                });
            }
            catch (FaultException<WCF_Suporte.FaultSTARSServices> ex)
            {
                throw new Exception(ex.Detail.Detalhes);
            }
        }

        public void SalvarAvatar(string login, string imageStringBase64, string extensaoArquivo)
        {
            try
            {
                WCF_Suporte.SuporteClient WCFSuporte = new WCF_Suporte.SuporteClient();
                WCFSuporte.SalvarFotoPerfil(new WCF_Suporte.DadosUsuario()
                {
                    Login = login
                }, imageStringBase64);
            }
            catch (FaultException<WCF_Suporte.FaultSTARSServices> ex)
            {
                throw new Exception(ex.Detail.Detalhes);
            }
        }

        public override void Inserir(Usuario usuario)
        {
            if (Consulta.Any(u => u.Login.Equals(usuario.Login) && string.IsNullOrEmpty(u.UsuarioExclusao)))
                throw new InvalidOperationException("Este login já está sendo usado por outro usuário.");

            if (Consulta.Any(u => u.CPF.Equals(usuario.CPF) && string.IsNullOrEmpty(u.UsuarioExclusao)))
                throw new InvalidOperationException("Este CPF já está sendo usado por outro usuário.");

            if (Consulta.Any(u => u.Email.Equals(usuario.Email) && string.IsNullOrEmpty(u.UsuarioExclusao)))
                throw new InvalidOperationException("Este e-mail já está sendo usado por outro usuário.");

            usuario.IDUsuario = Guid.NewGuid().ToString();

            base.Inserir(usuario);

            if (usuario.TipoDeAcesso.Equals(TipoDeAcesso.AD))
            {
                EnviarEmailParaUsuarioRecemCriadoAD(usuario);
            }
            else
            {
                EnviarEmailParaUsuarioRecemCriadoSistema(usuario);
            }

        }

        public override void Alterar(Usuario entidade)
        {

            Usuario tempUsuario = Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDUsuario.Equals(entidade.IDUsuario));
            if (tempUsuario == null)
            {
                throw new Exception("Não foi possível encontrar o usuário através do ID.");
            }
            else
            {
                if (Consulta.Any(u => u.Email.Equals(entidade.Email) && string.IsNullOrEmpty(u.UsuarioExclusao) && !entidade.Login.ToUpper().Equals(u.Login.ToUpper())))
                    throw new InvalidOperationException("Este e-mail já está sendo usado por outro usuário.");

                tempUsuario.DataExclusao = DateTime.Now;
                tempUsuario.UsuarioExclusao = entidade.UsuarioExclusao;
                base.Alterar(tempUsuario);

                entidade.IDUsuario = tempUsuario.IDUsuario;
                entidade.UsuarioExclusao = string.Empty;
                base.Inserir(entidade);

            }

        }

        public void DefinirSenha(NovaSenhaViewModel novaSenhaViewModel)
        {
            Usuario oUsuario = Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDUsuario.Equals(novaSenhaViewModel.IDUsuario));
            if (oUsuario == null)
            {
                throw new Exception("Não foi possível localizar o usuário através da identificação. Solicite um novo acesso.");
            }
            else
            {
                oUsuario.Senha = CreateHashFromPassword(novaSenhaViewModel.NovaSenha);
                Alterar(oUsuario);
                EnviarEmailParaUsuarioSenhaAlterada(oUsuario);
            }
        }

        public void SolicitarAcesso(string email)
        {
            List<Usuario> listaUsuarios = Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.Email.ToLower().Equals(email.ToLower())).ToList();
            if (listaUsuarios.Count() > 1 || listaUsuarios.Count() < 1)
            {
                listaUsuarios = Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.Login.ToLower().Equals(email.ToLower())).ToList();
                if (listaUsuarios.Count() > 1 || listaUsuarios.Count() < 1)
                {
                    throw new Exception("Não foi possível localizar este usuário no sistema através do e-mail. Tente novamente ou procure o Administrador.");
                }
            }

            EnviarEmailParaUsuarioSolicacaoAcesso(listaUsuarios[0]);
        }

        #region E-mails

        private void EnviarEmailParaUsuarioSolicacaoAcesso(Usuario usuario)
        {
            string sRemetente = ConfigurationManager.AppSettings["Web:Remetente"];
            string sSMTP = ConfigurationManager.AppSettings["Web:SMTP"];

            MailMessage mail = new MailMessage(sRemetente, usuario.Email);

            string PrimeiroNome = GISHelpers.Utils.Severino.PrimeiraMaiusculaTodasPalavras(usuario.Nome);
            if (PrimeiroNome.Contains(" "))
                PrimeiroNome = PrimeiroNome.Substring(0, PrimeiroNome.IndexOf(" "));

            mail.Subject = PrimeiroNome + ", este é o link para redinir sua senha";
            mail.Body = "<html style=\"font-family: Verdana; font-size: 11pt;\"><body>Olá, " + PrimeiroNome + ".";
            mail.Body += "<br /><br />";
            mail.Body += "<span style=\"color: #222;\">Redefina sua senha para começar novamente.";
            mail.Body += "<br /><br />";

            string sLink = "http://localhost:26717/Conta/DefinirNovaSenha/" + WebUtility.UrlEncode(GISHelpers.Utils.Criptografador.Criptografar(usuario.IDUsuario + "#" + DateTime.Now.ToString("yyyyMMdd"), 1)).Replace("%", "_@");

            mail.Body += "Para alterar sua senha do GiS, clique <a href=\"" + sLink + "\">aqui</a> ou cole o seguinte link no seu navegador.";
            mail.Body += "<br /><br />";
            mail.Body += sLink;
            mail.Body += "<br /><br />";
            mail.Body += "O link é válido por 24 horas, portanto, utilize-o imediatamente.";
            mail.Body += "<br /><br />";
            mail.Body += "Obrigado por utilizar o GiS!<br />";
            mail.Body += "<strong>Gestão Inteligente da Segurança</strong>";
            mail.Body += "</span>";
            mail.Body += "<br /><br />";
            mail.Body += "<span style=\"color: #aaa; font-size: 10pt; font-style: italic;\">Mensagem enviada automaticamente, favor não responder este email.</span>";
            mail.Body += "</body></html>";

            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;


            SmtpClient smtpClient = new SmtpClient(sSMTP, 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = ConfigurationManager.AppSettings["Web:Remetente"],
                Password = "sesmtajt"
            };

            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.Send(mail);

        }

        private void EnviarEmailParaUsuarioSenhaAlterada(Usuario usuario)
        {
            string sRemetente = ConfigurationManager.AppSettings["Web:Remetente"];
            string sSMTP = ConfigurationManager.AppSettings["Web:SMTP"];

            MailMessage mail = new MailMessage(sRemetente, usuario.Email);

            string PrimeiroNome = GISHelpers.Utils.Severino.PrimeiraMaiusculaTodasPalavras(usuario.Nome);
            if (PrimeiroNome.Contains(" "))
                PrimeiroNome = PrimeiroNome.Substring(0, PrimeiroNome.IndexOf(" "));

            mail.Subject = PrimeiroNome + ", sua senha foi redefinida.";

            mail.Body = "<html style=\"font-family: Verdana; font-size: 11pt;\"><body>Olá, " + PrimeiroNome + ".";
            mail.Body += "<br /><br />";
            mail.Body += "<span style=\"color: #222;\">Você redefiniu sua senha do GiS.";
            mail.Body += "<br /><br />";
            mail.Body += "Obrigado por utilizar o GiS!<br />";
            mail.Body += "<strong>Gestão Inteligente da Segurança</strong>";
            mail.Body += "</span>";
            mail.Body += "<br /><br />";
            mail.Body += "<span style=\"color: #aaa; font-size: 10pt; font-style: italic;\">Mensagem enviada automaticamente, favor não responder este email.</span>";
            mail.Body += "</body></html>";

            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;


            SmtpClient smtpClient = new SmtpClient(sSMTP, 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = ConfigurationManager.AppSettings["Web:Remetente"],
                Password = "sesmtajt"
            };

            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.Send(mail);

        }

        private void EnviarEmailParaUsuarioRecemCriadoSistema(Usuario usuario)
        {
            string sRemetente = ConfigurationManager.AppSettings["Web:Remetente"];
            string sSMTP = ConfigurationManager.AppSettings["Web:SMTP"];

            MailMessage mail = new MailMessage(sRemetente, usuario.Email);

            string PrimeiroNome = GISHelpers.Utils.Severino.PrimeiraMaiusculaTodasPalavras(usuario.Nome);
            if (PrimeiroNome.Contains(" "))
                PrimeiroNome = PrimeiroNome.Substring(0, PrimeiroNome.IndexOf(" "));

            mail.Subject = PrimeiroNome + ", seja bem-vindo!";
            mail.Body = "<html style=\"font-family: Verdana; font-size: 11pt;\"><body>Olá, " + PrimeiroNome + ";";
            mail.Body += "<br /><br />";

            string NomeUsuarioInclusao = usuario.UsuarioInclusao;
            Usuario uInclusao = Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.Login.Equals(usuario.UsuarioInclusao));
            if (uInclusao != null && !string.IsNullOrEmpty(uInclusao.Nome))
                NomeUsuarioInclusao = uInclusao.Nome;


            string sLink = "http://localhost:26717/Conta/DefinirNovaSenha/" + WebUtility.UrlEncode(GISHelpers.Utils.Criptografador.Criptografar(usuario.IDUsuario + "#" + DateTime.Now.ToString("yyyyMMdd"), 1)).Replace("%", "_@");

            mail.Body += "Você foi cadastrado no sistema GiS - Gestão Inteligente da Segurança pelo " + GISHelpers.Utils.Severino.PrimeiraMaiusculaTodasPalavras(NomeUsuarioInclusao) + ".";
            mail.Body += "<br /><br />";
            mail.Body += "Clique <a href=\"" + sLink + "\">aqui</a> para ativar sua conta ou cole o seguinte link no seu navegador.";
            mail.Body += "<br /><br />";
            mail.Body += sLink;
            mail.Body += "<br /><br />";
            mail.Body += "Obrigado por utilizar o GiS!<br />";
            mail.Body += "<strong>Gestão Inteligente da Segurança</strong>";
            mail.Body += "<br /><br />";
            mail.Body += "<span style=\"color: #ccc; font-style: italic;\">Mensagem enviada automaticamente, favor não responder este email.</span>";
            mail.Body += "</body></html>";

            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient(sSMTP, 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = ConfigurationManager.AppSettings["Web:Remetente"],
                Password = "sesmtajt"
            };

            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.Send(mail);

        }

        private void EnviarEmailParaUsuarioRecemCriadoAD(Usuario usuario)
        {
            string sRemetente = ConfigurationManager.AppSettings["Web:Remetente"];
            string sSMTP = ConfigurationManager.AppSettings["Web:SMTP"];

            MailMessage mail = new MailMessage(sRemetente, usuario.Email);

            string PrimeiroNome = GISHelpers.Utils.Severino.PrimeiraMaiusculaTodasPalavras(usuario.Nome);
            if (PrimeiroNome.Contains(" "))
                PrimeiroNome = PrimeiroNome.Substring(0, PrimeiroNome.IndexOf(" "));

            mail.Subject = PrimeiroNome + ", seja bem-vindo!";
            mail.Body = "<html style=\"font-family: Verdana; font-size: 11pt;\"><body>Olá, " + PrimeiroNome + ".";
            mail.Body += "<br /><br />";

            string NomeUsuarioInclusao = usuario.UsuarioInclusao;
            Usuario uInclusao = Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.Login.Equals(usuario.UsuarioInclusao));
            if (uInclusao != null && !string.IsNullOrEmpty(uInclusao.Nome))
                NomeUsuarioInclusao = uInclusao.Nome;

            string sLink = "http://localhost:26717/";

            mail.Body += "Você foi cadastrado no sistema GiS - Gestão Inteligente da Segurança pelo " + NomeUsuarioInclusao + ".";
            mail.Body += "<br /><br />";
            mail.Body += "Clique <a href=\"" + sLink + "\">aqui</a> para acessar a sua conta ou cole o seguinte link no seu navegador.";
            mail.Body += "<br /><br />";
            mail.Body += sLink;
            mail.Body += "<br /><br />";
            mail.Body += "Obrigado por utilizar o GiS!<br />";
            mail.Body += "<strong>Gestão Inteligente da Segurança</strong>";
            mail.Body += "<br /><br />";
            mail.Body += "<span style=\"color: #ccc; font-style: italic;\">Mensagem enviada automaticamente, favor não responder este email.</span>";
            mail.Body += "</body></html>";

            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient(sSMTP, 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = ConfigurationManager.AppSettings["Web:Remetente"],
                Password = "sesmtajt"
            };

            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.Send(mail);

        }

        #endregion

        #region Senhas

        [ComVisible(false)]
        private string CreateHashFromPassword(string pstrOriginalPassword)
        {
            if (string.IsNullOrEmpty(pstrOriginalPassword))
                return string.Empty;

            string str3 = ConvertToHashedString(pstrOriginalPassword).Substring(0, 5);
            byte[] bytes = Encoding.UTF8.GetBytes(pstrOriginalPassword + str3);
            HashAlgorithm lobjHash = new MD5CryptoServiceProvider();
            return Convert.ToBase64String(lobjHash.ComputeHash(bytes));
        }

        [ComVisible(false)]
        private string ConvertToHashedString(string pstrOriginal)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(pstrOriginal);
            HashAlgorithm lobjHash = new MD5CryptoServiceProvider();
            return Convert.ToBase64String(lobjHash.ComputeHash(bytes));
        }

        #endregion


    }
}
