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
    public class AtividadeAlocadaBusiness : BaseBusiness<AtividadeAlocada>, IAtividadeAlocadaBusiness
    {

        public override void Inserir(AtividadeAlocada pAtividadeAlocada)
        {
            
            
            pAtividadeAlocada.IDAtividadeAlocada = Guid.NewGuid().ToString();
           // pAtividadeAlocada.Admitido = "Admitido";
            
            base.Inserir(pAtividadeAlocada);

           

        }

        public override void Alterar(AtividadeAlocada pAtividadeAlocada)
        {


            List<AtividadeAlocada> lAtividadeAlocada = Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.idAlocacao.Equals(pAtividadeAlocada.idAlocacao) && p.idAtividadesDoEstabelecimento.Equals(pAtividadeAlocada.idAtividadesDoEstabelecimento)).ToList();
            if (lAtividadeAlocada.Count.Equals(1))
            {
                AtividadeAlocada oAtividadeAlocada = lAtividadeAlocada[0];

                oAtividadeAlocada.UsuarioExclusao = pAtividadeAlocada.UsuarioExclusao;
                oAtividadeAlocada.DataExclusao = pAtividadeAlocada.DataExclusao;

                base.Alterar(oAtividadeAlocada);
            }








            //AtividadeAlocada tempAtividadeAlocada = Consulta.FirstOrDefault(p => p.IDAtividadeAlocada.Equals(pAtividadeAlocada.IDAtividadeAlocada));
            //if (tempAtividadeAlocada == null)
            //{
            //    throw new Exception("Não foi possível encontrar a Atividade através do ID.");
            //}
            //else
            //{

            //    tempAtividadeAlocada.idAtividadesDoEstabelecimento = pAtividadeAlocada.idAtividadesDoEstabelecimento;
               
                
                

            //    base.Alterar(tempAtividadeAlocada);

                

            //}

        }

    }
}
