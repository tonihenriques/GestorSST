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
    public class EmpregadoBusiness : BaseBusiness<Empregado>, IEmpregadoBusiness
    {

        public override void Inserir(Empregado pEmpregado)
        {
            //string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
            //sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
            //sLocalFile = Path.Combine(sLocalFile, "Empresa");
            //sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
            //sLocalFile = Path.Combine(sLocalFile, pEmpregado.Imagem);

            //if (!File.Exists(sLocalFile))
            //    throw new Exception("Não foi possível localizar o arquivo '" + pEmpregado.Imagem + "'. Favor realizar novamente o upload do mesmo.");

            pEmpregado.IDEmpregado = Guid.NewGuid().ToString();

            base.Inserir(pEmpregado);

            //string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\EmpregadoImagens\\" + pEmpregado.IDEmpregado;
            //if (!Directory.Exists(sDiretorio))
            //    Directory.CreateDirectory(sDiretorio);

            //if (File.Exists(sLocalFile))
            //    File.Move(sLocalFile, sDiretorio + "\\" + pEmpregado.Imagem);

        }

        public override void Alterar(Empregado pEmpregado)
        {

            Empregado tempEmpregado = Consulta.FirstOrDefault(p => p.IDEmpregado.Equals(pEmpregado.IDEmpregado));
            if (tempEmpregado == null)
            {
                throw new Exception("Não foi possível encontrar o Empregado.");
            }

            tempEmpregado.Nome = pEmpregado.Nome;
            tempEmpregado.CPF = pEmpregado.CPF;
            tempEmpregado.DataNascimento = pEmpregado.DataNascimento;
            tempEmpregado.Email = pEmpregado.Email;


            base.Alterar(tempEmpregado);

            

        }

    }


}
