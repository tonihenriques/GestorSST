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
    public class PossiveisDanosBusiness : BaseBusiness<PossiveisDanos>, IPossiveisDanosBusiness
    {

        public override void Inserir(PossiveisDanos pPossiveisDanos)
        {
            
           
            pPossiveisDanos.IDPossiveisDanos = Guid.NewGuid().ToString();
            
            base.Inserir(pPossiveisDanos);

            

        }

        public override void Alterar(PossiveisDanos pPossiveisDanos)
        {

            PossiveisDanos tempPossiveisDanos = Consulta.FirstOrDefault(p => p.IDPossiveisDanos.Equals(pPossiveisDanos.IDPossiveisDanos));
            if (tempPossiveisDanos == null)
            {
                throw new Exception("Não foi possível encontrar o possível dano através do ID.");
            }
            else
            {
                tempPossiveisDanos.DescricaoDanos = pPossiveisDanos.DescricaoDanos;

                base.Alterar(tempPossiveisDanos);

                

            }

        }

    }
}
