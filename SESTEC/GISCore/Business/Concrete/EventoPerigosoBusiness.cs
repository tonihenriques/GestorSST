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
    public class EventoPerigosoBusiness : BaseBusiness<EventoPerigoso>, IEventoPerigosoBusiness
    {

        public override void Inserir(EventoPerigoso pEvento)
        {
            
            

            pEvento.IDEventoPerigoso = Guid.NewGuid().ToString();
            
            base.Inserir(pEvento);

            

        }

        public override void Alterar(EventoPerigoso pEvento)
        {

            EventoPerigoso tempEvento = Consulta.FirstOrDefault(p => p.IDEventoPerigoso.Equals(pEvento.IDEventoPerigoso));
            if (tempEvento == null)
            {
                throw new Exception("Não foi possível encontrar o Evento Perigoso através do ID.");
            }
            else
            {


                tempEvento.Descricao = pEvento.Descricao;
                               

                base.Alterar(tempEvento);

            }

        }

    }
}
