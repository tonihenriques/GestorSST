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
    public class EstabelecimentoBusiness : BaseBusiness<Estabelecimento>, IEstabelecimentoBusiness
    {
        public override void Inserir(Estabelecimento pTEstabelecimento)
        {
            pTEstabelecimento.IDEstabelecimento = Guid.NewGuid().ToString();
            base.Inserir(pTEstabelecimento);
        }
        
        public override void Alterar(Estabelecimento pTEstabelecimento)
        {

            Estabelecimento tempEstabelecimento = Consulta.FirstOrDefault(p => p.IDEstabelecimento.Equals(pTEstabelecimento.IDEstabelecimento));
            if (tempEstabelecimento == null)
            {
                throw new Exception("Não foi possível encontrar o Estabelecimento.");
            }
            
            tempEstabelecimento.IDEstabelecimento = pTEstabelecimento.IDEstabelecimento;
            tempEstabelecimento.Codigo = pTEstabelecimento.Codigo;
            tempEstabelecimento.NomeCompleto = pTEstabelecimento.NomeCompleto;
            tempEstabelecimento.TipoDeEstabelecimento = pTEstabelecimento.TipoDeEstabelecimento;


            base.Alterar(tempEstabelecimento);
            
        }

    }



}

