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
    public class ExposicaoBusiness : BaseBusiness<Exposicao>, IExposicaoBusiness
    {

        public override void Inserir(Exposicao pExposicao)
        {

            if (Consulta.Any(u => u.IDExposicao.Equals(pExposicao.IDExposicao)))
                throw new InvalidOperationException("Não é possível inserir esta exposição, pois já existe uma exposição com este ID.");
            
            pExposicao.IDExposicao = Guid.NewGuid().ToString();
            
            base.Inserir(pExposicao);

           
        }

        public override void Alterar(Exposicao pExposicao)
        {

            Exposicao tempExposicao = Consulta.FirstOrDefault(p => p.IDExposicao.Equals(pExposicao.IDExposicao));
            if (tempExposicao == null)
            {
                throw new Exception("Não foi possível encontrar a exposicao através do ID.");
            }
            else
            {


                //tempExposicao.idAtividadesDoEstabelecimento = pExposicao.idAtividadesDoEstabelecimento;
                //tempExposicao.idEstabelecimentoImagens = pExposicao.idEstabelecimentoImagens;                
                tempExposicao.EExposicaoCalor = pExposicao.EExposicaoCalor;
                tempExposicao.EExposicaoInsalubre = pExposicao.EExposicaoInsalubre;


                base.Alterar(tempExposicao);

                
                
            }

        }

    }
}
