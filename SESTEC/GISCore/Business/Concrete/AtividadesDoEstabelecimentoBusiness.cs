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
    public class AtividadesDoEstabelecimentoBusiness : BaseBusiness<AtividadesDoEstabelecimento>, IAtividadesDoEstabelecimentoBusiness
    {

        public override void Inserir(AtividadesDoEstabelecimento pAtividadesDoEstabelecimento)
        {



            string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
            sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
            sLocalFile = Path.Combine(sLocalFile, "Empresa");
            sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
            sLocalFile = Path.Combine(sLocalFile, pAtividadesDoEstabelecimento.Imagem);

            if (!File.Exists(sLocalFile))
                throw new Exception("Não foi possível localizar o arquivo '" + pAtividadesDoEstabelecimento.Imagem + "'. Favor realizar novamente o upload do mesmo.");

            pAtividadesDoEstabelecimento.IDAtividadesDoEstabelecimento = Guid.NewGuid().ToString();

            base.Inserir(pAtividadesDoEstabelecimento);

            string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\AtividadesEstabelecimentoImagens\\" + pAtividadesDoEstabelecimento.IDAtividadesDoEstabelecimento;
            if (!Directory.Exists(sDiretorio))
                Directory.CreateDirectory(sDiretorio);

            if (File.Exists(sLocalFile))
                File.Move(sLocalFile, sDiretorio + "\\" + pAtividadesDoEstabelecimento.Imagem);

        }

        public override void Alterar(AtividadesDoEstabelecimento pRiscosDoEstabelecimento)
        {

            AtividadesDoEstabelecimento tempRiscosDoEstabelecimento = Consulta.FirstOrDefault(p => p.IDAtividadesDoEstabelecimento.Equals(pRiscosDoEstabelecimento.IDAtividadesDoEstabelecimento));
            if (tempRiscosDoEstabelecimento == null)
            {
                throw new Exception("Não foi possível encontrar o Estabelecimento através do ID.");
            }
            else
            {
                //string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
                //sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
                //sLocalFile = Path.Combine(sLocalFile, "Empresa");
                //sLocalFile = Path.Combine(sLocalFile, "LoginTeste");
                //sLocalFile = Path.Combine(sLocalFile, pRiscosDoEstabelecimento.Imagem);

                //bool bLogoAlterada = false;

                //if (!tempRiscosDoEstabelecimento.Imagem.Equals(pRiscosDoEstabelecimento.Imagem))
                //{
                //    bLogoAlterada = true;
                //    if (!File.Exists(sLocalFile))
                //    {
                //        throw new Exception("Não foi possível localizar o arquivo '" + pRiscosDoEstabelecimento.Imagem + "'. Favor realizar novamente o upload do mesmo.");
                //    }
                //}

                tempRiscosDoEstabelecimento.Imagem = pRiscosDoEstabelecimento.Imagem;
                tempRiscosDoEstabelecimento.NomeDaImagem = pRiscosDoEstabelecimento.NomeDaImagem;
                tempRiscosDoEstabelecimento.IDEstabelecimentoImagens = pRiscosDoEstabelecimento.IDEstabelecimentoImagens;
                //tempRiscosDoEstabelecimento.IDAlocacao = pRiscosDoEstabelecimento.IDAlocacao;
                tempRiscosDoEstabelecimento.Imagem = pRiscosDoEstabelecimento.Imagem;
                tempRiscosDoEstabelecimento.IDAtividadesDoEstabelecimento = pRiscosDoEstabelecimento.IDAtividadesDoEstabelecimento;
                //tempRiscosDoEstabelecimento.IDEventoPerigoso = pRiscosDoEstabelecimento.IDEventoPerigoso;
                //tempRiscosDoEstabelecimento.PossiveisDanos = pRiscosDoEstabelecimento.PossiveisDanos;
                //tempRiscosDoEstabelecimento.TipoDeRisco = pRiscosDoEstabelecimento.TipoDeRisco;
                //tempRiscosDoEstabelecimento.FonteGeradora = pRiscosDoEstabelecimento.FonteGeradora;
                //tempRiscosDoEstabelecimento.EventoPerigoso = pRiscosDoEstabelecimento.EventoPerigoso;
                //tempRiscosDoEstabelecimento.Tragetoria = pRiscosDoEstabelecimento.Tragetoria;
                tempRiscosDoEstabelecimento.Ativo = pRiscosDoEstabelecimento.Ativo;
                tempRiscosDoEstabelecimento.DescricaoDestaAtividade = pRiscosDoEstabelecimento.DescricaoDestaAtividade;
                base.Alterar(tempRiscosDoEstabelecimento);

                //if (bLogoAlterada)
                //{
                //    string sDiretorio = ConfigurationManager.AppSettings["DiretorioRaiz"] + "\\Images\\RiscosEstabelecimentoImagens\\" + pRiscosDoEstabelecimento.IDAtividadesDoEstabelecimento;

                //    if (!Directory.Exists(sDiretorio))
                //    {
                //        Directory.CreateDirectory(sDiretorio);
                //    }
                //    else
                //    {
                //        foreach (string iArq in Directory.GetFiles(sDiretorio))
                //        {
                //            File.Delete(iArq);
                //        }

                //        if (File.Exists(sLocalFile))
                //            File.Move(sLocalFile, sDiretorio + "\\" + pRiscosDoEstabelecimento.Imagem);
                //    }

                //}

            }

        }

    }
}
