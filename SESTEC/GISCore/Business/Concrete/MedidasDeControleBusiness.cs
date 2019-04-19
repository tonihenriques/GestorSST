using System;
using GISCore.Business.Abstract;
using GISModel.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace GISCore.Business.Concrete
{
    public class MedidasDeControleBusiness:BaseBusiness<MedidasDeControleExistentes>, IMedidasDeControleBusiness
    {

        public override void Inserir(MedidasDeControleExistentes pMedidasDeControleExistentes)
        {

            string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
            sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
            sLocalFile = Path.Combine(sLocalFile, "Empresa");
            sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
            sLocalFile = Path.Combine(sLocalFile, pMedidasDeControleExistentes.Imagem);

            if (!File.Exists(sLocalFile))
                throw new Exception("Não foi possível localizar o arquivo '" + pMedidasDeControleExistentes.Imagem + "'. Favor realizar novamente o upload do mesmo.");

            pMedidasDeControleExistentes.IDMedidasDeControle = Guid.NewGuid().ToString();

            base.Inserir(pMedidasDeControleExistentes);

            string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\MedidasDeControle\\" + pMedidasDeControleExistentes.IDMedidasDeControle;
            if (!Directory.Exists(sDiretorio))
                Directory.CreateDirectory(sDiretorio);

            if (File.Exists(sLocalFile))
                File.Move(sLocalFile, sDiretorio + "\\" + pMedidasDeControleExistentes.Imagem);

        }

        public override void Alterar(MedidasDeControleExistentes pMedidasDeControleExistentes)
        {

            MedidasDeControleExistentes tempMedidasDeControleExistentes = Consulta.FirstOrDefault(p => p.IDMedidasDeControle.Equals(pMedidasDeControleExistentes.IDMedidasDeControle));
            if (tempMedidasDeControleExistentes == null)
            {
                throw new Exception("Não foi possível encontrar o Estabelecimento através do ID.");
            }
            else
            {
                string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
                sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
                sLocalFile = Path.Combine(sLocalFile, "Empresa");
                sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
                sLocalFile = Path.Combine(sLocalFile, pMedidasDeControleExistentes.Imagem);

                bool bLogoAlterada = false;

                if (!tempMedidasDeControleExistentes.Imagem.Equals(pMedidasDeControleExistentes.Imagem))
                {
                    bLogoAlterada = true;
                    if (!File.Exists(sLocalFile))
                    {
                        throw new Exception("Não foi possível localizar o arquivo '" + pMedidasDeControleExistentes.Imagem + "'. Favor realizar novamente o upload do mesmo.");
                    }
                }

                tempMedidasDeControleExistentes.NomeDaImagem = tempMedidasDeControleExistentes.NomeDaImagem;
                tempMedidasDeControleExistentes.MedidasExistentes = tempMedidasDeControleExistentes.MedidasExistentes;
                tempMedidasDeControleExistentes.EClassificacaoDaMedida = tempMedidasDeControleExistentes.EClassificacaoDaMedida;
                tempMedidasDeControleExistentes.Imagem = tempMedidasDeControleExistentes.Imagem;
  

                base.Alterar(tempMedidasDeControleExistentes);

                if (bLogoAlterada)
                {
                    string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\MedidasDeControle\\" + pMedidasDeControleExistentes.IDMedidasDeControle;

                    if (!Directory.Exists(sDiretorio))
                    {
                        Directory.CreateDirectory(sDiretorio);
                    }
                    else
                    {
                        foreach (string iArq in Directory.GetFiles(sDiretorio))
                        {
                            File.Delete(iArq);
                        }

                        if (File.Exists(sLocalFile))
                            File.Move(sLocalFile, sDiretorio + "\\" + pMedidasDeControleExistentes.Imagem);
                    }

                }

            }

        }

    }

}

