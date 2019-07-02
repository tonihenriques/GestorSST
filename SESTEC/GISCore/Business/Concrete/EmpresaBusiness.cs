using GISCore.Business.Abstract;
using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Business.Concrete
{
    public class EmpresaBusiness : BaseBusiness<Empresa>, IEmpresaBusiness
    {

        public override void Inserir(Empresa pEmpresa)
        {
            
            if (Consulta.Any(u => u.CNPJ.Equals(pEmpresa.CNPJ.Trim())))
                throw new InvalidOperationException("Não é possível inserir empresa, pois já existe uma empresa registrada com este CNPJ.");

            if (Consulta.Any(u => u.NomeFantasia.ToUpper().Equals(pEmpresa.NomeFantasia.Trim().ToUpper())))
                throw new InvalidOperationException("Não é possível inserir empresa, pois já existe uma empresa registrada com este Nome Fatasia.");

            string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
            sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
            sLocalFile = Path.Combine(sLocalFile, "Empresa");
            sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
            sLocalFile = Path.Combine(sLocalFile, pEmpresa.URL_LogoMarca);

            if (!File.Exists(sLocalFile))
                throw new Exception("Não foi possível localizar o arquivo '" + pEmpresa.URL_LogoMarca + "'. Favor realizar novamente o upload do mesmo.");

            pEmpresa.IDEmpresa = Guid.NewGuid().ToString();

            base.Inserir(pEmpresa);

            string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\Empresas\\" + pEmpresa.CNPJ.Replace("/", "").Replace(".", "").Replace("-", "");
            if (!Directory.Exists(sDiretorio))
                Directory.CreateDirectory(sDiretorio);

            if (File.Exists(sLocalFile))
                File.Move(sLocalFile, sDiretorio + "\\" + pEmpresa.URL_LogoMarca);
            
        }

        public override void Alterar(Empresa pEmpresa)
        {
            if (Consulta.Any(u => u.CNPJ.Equals(pEmpresa.CNPJ.Trim()) && !u.IDEmpresa.Equals(pEmpresa.IDEmpresa)))
                throw new InvalidOperationException("Não é possível atualizar esta empresa, pois o CNPJ já está sendo usado por outra empresa.");

            if (Consulta.Any(u => u.NomeFantasia.ToUpper().Equals(pEmpresa.NomeFantasia.Trim().ToUpper()) && !u.IDEmpresa.Equals(pEmpresa.IDEmpresa)))
                throw new InvalidOperationException("Não é possível atualizar esta empresa, pois o Nome Fatasia está sendo usado por outra empresa.");

            Empresa tempEmpresa = Consulta.FirstOrDefault(p => p.IDEmpresa.Equals(pEmpresa.IDEmpresa));
            if (tempEmpresa == null)
            {
                throw new Exception("Não foi possível encontrar a empresa através do ID.");
            }
            else
            {
                string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
                sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
                sLocalFile = Path.Combine(sLocalFile, "Empresa");
                sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
                sLocalFile = Path.Combine(sLocalFile, pEmpresa.URL_LogoMarca);

                bool bLogoAlterada = false;

                if (!tempEmpresa.URL_LogoMarca.Equals(pEmpresa.URL_LogoMarca)) {
                    bLogoAlterada = true;
                    if (!File.Exists(sLocalFile))
                    {
                        throw new Exception("Não foi possível localizar o arquivo '" + pEmpresa.URL_LogoMarca + "'. Favor realizar novamente o upload do mesmo.");
                    }
                }

                tempEmpresa.NomeFantasia = pEmpresa.NomeFantasia;
                tempEmpresa.RazaoSocial = pEmpresa.RazaoSocial;
                tempEmpresa.CNPJ = pEmpresa.CNPJ;
                tempEmpresa.URL_AD = pEmpresa.URL_AD;
                tempEmpresa.URL_LogoMarca = pEmpresa.URL_LogoMarca;
                tempEmpresa.URL_WS = pEmpresa.URL_WS;
                tempEmpresa.URL_Site = pEmpresa.URL_Site;

                base.Alterar(tempEmpresa);

                if (bLogoAlterada)
                {
                    string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\Empresas\\" + pEmpresa.CNPJ.Replace("/", "").Replace(".", "").Replace("-", "");
                    if (!Directory.Exists(sDiretorio))
                    {
                        Directory.CreateDirectory(sDiretorio);
                    }
                    else
                    {
                        foreach (string iArq in Directory.GetFiles(sDiretorio)) {
                            File.Delete(iArq);    
                        }

                        if (File.Exists(sLocalFile))
                            File.Move(sLocalFile, sDiretorio + "\\" + pEmpresa.URL_LogoMarca);
                    }

                }
                
            }

        }

    }
}
