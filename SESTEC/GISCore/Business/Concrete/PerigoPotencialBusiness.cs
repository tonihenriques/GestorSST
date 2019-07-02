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
    public class PerigoPotencialBusiness : BaseBusiness<PerigoPotencial>, IPerigoPotencialBusiness
    {

        public override void Inserir(PerigoPotencial pPerigo)
        {
            pPerigo.IDPerigoPotencial = Guid.NewGuid().ToString();

            base.Inserir(pPerigo);

        }

        public override void Alterar(PerigoPotencial pPerigo)
        {
            PerigoPotencial tempPerigoPotencial = Consulta.FirstOrDefault(p => p.IDPerigoPotencial.Equals(pPerigo.IDPerigoPotencial));
            if (tempPerigoPotencial == null)
            {
                throw new Exception("Não foi possível encontrar o Evento através do ID.");
            }
            else
            {
                tempPerigoPotencial.DescricaoEvento = pPerigo.DescricaoEvento;

                base.Alterar(tempPerigoPotencial);



            }

        }

    }
}
