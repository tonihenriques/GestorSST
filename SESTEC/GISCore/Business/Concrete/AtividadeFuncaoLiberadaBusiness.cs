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
    public class AtividadeFuncaoLiberadaBusiness : BaseBusiness<AtividadeFuncaoLiberada>, IAtividadeFuncaoLiberadaBusiness
    {

        public override void Inserir(AtividadeFuncaoLiberada pAtividadeFuncaoLiberada)
        {
            
            
            pAtividadeFuncaoLiberada.IDAtividadeFuncaoLiberada = Guid.NewGuid().ToString();
           // pAtividadeAlocada.Admitido = "Admitido";
            
            base.Inserir(pAtividadeFuncaoLiberada);

           

        }

        public override void Alterar(AtividadeFuncaoLiberada pAtividadeFuncaoLiberada)
        {


            List<AtividadeFuncaoLiberada> lAtividadeFuncaoLiberada = Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDAtividade.Equals(pAtividadeFuncaoLiberada.IDAtividade)&& p.IDAlocacao.Equals(pAtividadeFuncaoLiberada.IDAlocacao)).ToList();

            if (lAtividadeFuncaoLiberada.Count.Equals(1))
            {
                AtividadeFuncaoLiberada oAtividadeFuncaoLiberada = lAtividadeFuncaoLiberada[0];

                oAtividadeFuncaoLiberada.UsuarioExclusao = pAtividadeFuncaoLiberada.UsuarioExclusao;
                oAtividadeFuncaoLiberada.DataExclusao = pAtividadeFuncaoLiberada.DataExclusao;

                base.Alterar(oAtividadeFuncaoLiberada);
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
