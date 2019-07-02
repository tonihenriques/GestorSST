using GISCore.Business.Abstract;
using GISHelpers.Utils;
using GISModel.DTO.Conta;
using GISModel.Entidades;
using GISWeb.Infraestrutura.Provider.Abstract;
using Ninject;
using System;
using System.Configuration;
using System.Runtime.Caching;
using System.Web;
using System.Web.Security;

namespace GISWeb.Infraestrutura.Provider.Concrete
{
    public class CustomAuthorizationProvider : ICustomAuthorizationProvider
    {

        [Inject]
        public IUsuarioBusiness UsuarioBusiness { get; set; }

        private Usuario usuarioPersistido;
        private string token;

        //############################################################################################
        //Jogada para permitir combinação de SlidingExpiration (que não aceita persistência do cookie)
        //com persistência:
        //O model salvo na MemoryCache do servidor está configurado com SlidingExpiration, ao passo 
        //que o ticket gerado será com absolute; então, mesmo que o cookie esteja 'válido' na máquina
        //do usuário, dado o tempo máximo sem acesso, o MemoryCache expirará e o usuário será forçado 
        //a logar novamente
        //############################################################################################

        public bool EstaAutenticado
        {
            get
            {
                try
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                    if (cookie != null)
                    {
                        if (!string.IsNullOrEmpty(cookie.Value))
                        {
                            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                            if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                            {
                                token = Compactador.Descompactar(ticket.UserData);

                                MemoryCache cacheStore = MemoryCache.Default;

                                if (cacheStore.Contains(token))
                                {
                                    usuarioPersistido = (Usuario)cacheStore.Get(token);

                                    //########################################################################
                                    //Podemos implementar aqui ainda outros testes em cima do model armazenado 
                                    //como cookie na máquina do usuário.

                                    if (usuarioPersistido != null)
                                        return true;
                                }
                            }
                        }
                    }
                }
                catch { }

                return false;
            }
        }

        public Usuario UsuarioAutenticado
        {
            get
            {
                if (EstaAutenticado)
                    return usuarioPersistido;
                else
                    return null;
            }
        }

        public void Logar(AutenticacaoModel autenticacaoModel)
        {
            usuarioPersistido = UsuarioBusiness.ValidarCredenciais(autenticacaoModel);
            if (usuarioPersistido == null)
            {
                throw new Exception("Não foi possível relacionar um usuário com as permissões do módulo " + ConfigurationManager.AppSettings["Web:NomeModulo"] + " à credencial fornecida. Por favor, entre em contato com um dos administradores do módulo.");
            }
            else
            {
                int expiracao;
                try
                {
                    expiracao = Convert.ToInt32(FormsAuthentication.Timeout.TotalMinutes);
                }
                catch { expiracao = 120; }

                token = SalvarEmCacheEGerarToken(usuarioPersistido, expiracao);
                GerarTicketEArmazenarComoCookie(token, usuarioPersistido.Login);
            }
        }

        public void Deslogar()
        {
            if (EstaAutenticado)
            {
                MemoryCache cacheStore = MemoryCache.Default;

                if (!string.IsNullOrWhiteSpace(token) && cacheStore.Contains(token))
                    cacheStore.Remove(token);
            }

            FormsAuthentication.SignOut();

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie1);
        }

        private string SalvarEmCacheEGerarToken(Usuario autenticacaoModel, int expiracaoEmMinutos)
        {
            var token = Guid.NewGuid().ToString();

            MemoryCache cacheStore = MemoryCache.Default;

            CacheItem cacheItem = new CacheItem(token, autenticacaoModel);
            CacheItemPolicy cachePolicy = new CacheItemPolicy();

            cachePolicy.SlidingExpiration = TimeSpan.FromMinutes(Convert.ToDouble(expiracaoEmMinutos));
            cachePolicy.Priority = CacheItemPriority.NotRemovable;

            cacheStore.Add(cacheItem, cachePolicy);

            return token;
        }

        private void GerarTicketEArmazenarComoCookie(string token, string login, int expiracaoEmMinutos = 480)
        {
            var ticketEncriptado = GerarTicketEncriptado(token, login, expiracaoEmMinutos);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncriptado);
            authCookie.Expires = DateTime.Now.AddMinutes(expiracaoEmMinutos);

            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        private string GerarTicketEncriptado(string token, string login, int expiracaoEmMinutos)
        {
            var tokenCompactado = Compactador.Compactar(token);

            var ticket = new FormsAuthenticationTicket(1, login,
                DateTime.Now, DateTime.Now.AddMinutes(expiracaoEmMinutos), false, tokenCompactado,
                FormsAuthentication.FormsCookiePath);

            var ticketEncriptado = FormsAuthentication.Encrypt(ticket);

            return ticketEncriptado;
        }

    }
}