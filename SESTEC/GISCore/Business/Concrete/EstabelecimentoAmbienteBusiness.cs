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
    public class EstabelecimentoAmbienteBusiness : BaseBusiness<EstabelecimentoAmbiente>, IEstabelecimentoAmbienteBusiness
    {

        public override void Inserir(EstabelecimentoAmbiente pEstabelecimentoImagens)
        {

            
            
            string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
            sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
            sLocalFile = Path.Combine(sLocalFile, "Empresa");
            sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
            sLocalFile = Path.Combine(sLocalFile, pEstabelecimentoImagens.Imagem);

            if (!File.Exists(sLocalFile))
                throw new Exception("Não foi possível localizar o arquivo '" + pEstabelecimentoImagens.Imagem + "'. Favor realizar novamente o upload do mesmo.");

            pEstabelecimentoImagens.IDEstabelecimentoImagens = Guid.NewGuid().ToString();

            base.Inserir(pEstabelecimentoImagens);

            string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\EstabelecimentoImagens\\" + pEstabelecimentoImagens.IDEstabelecimentoImagens;
            if (!Directory.Exists(sDiretorio))
                Directory.CreateDirectory(sDiretorio);

            if (File.Exists(sLocalFile))
                File.Move(sLocalFile, sDiretorio + "\\" + pEstabelecimentoImagens.Imagem);

        }

        public override void Alterar(EstabelecimentoAmbiente pEstabelecimentoImagens)
        {

            EstabelecimentoAmbiente tempEstabelecimentoImagens = Consulta.FirstOrDefault(p => p.IDEstabelecimentoImagens.Equals(pEstabelecimentoImagens.IDEstabelecimentoImagens));
            if (tempEstabelecimentoImagens == null)
            {
                throw new Exception("Não foi possível encontrar a empresa através do ID.");
            }
            else
            {
                string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
                sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
                sLocalFile = Path.Combine(sLocalFile, "Empresa");
                sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
                sLocalFile = Path.Combine(sLocalFile, pEstabelecimentoImagens.Imagem);

                bool bLogoAlterada = false;

                if (!tempEstabelecimentoImagens.Imagem.Equals(pEstabelecimentoImagens.Imagem))
                {
                    bLogoAlterada = true;
                    if (!File.Exists(sLocalFile))
                    {
                        throw new Exception("Não foi possível localizar o arquivo '" + pEstabelecimentoImagens.Imagem + "'. Favor realizar novamente o upload do mesmo.");
                    }
                }

                tempEstabelecimentoImagens.NomeDaImagem = tempEstabelecimentoImagens.NomeDaImagem;
                tempEstabelecimentoImagens.ResumoDoLocal = tempEstabelecimentoImagens.ResumoDoLocal;
                tempEstabelecimentoImagens.IDEstabelecimento = tempEstabelecimentoImagens.IDEstabelecimento;
                tempEstabelecimentoImagens.Imagem = tempEstabelecimentoImagens.Imagem;
                

                base.Alterar(tempEstabelecimentoImagens);

                if (bLogoAlterada)
                {
                    string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\EstabelecimentoImagens\\" + pEstabelecimentoImagens.IDEstabelecimento;
                    
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
                            File.Move(sLocalFile, sDiretorio + "\\" + pEstabelecimentoImagens.Imagem);
                    }

                }

            }

        }

    }
}
