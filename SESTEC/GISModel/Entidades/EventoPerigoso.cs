using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbEventoPerigoso")]
    public class EventoPerigoso: EntidadeBase
    {
        [Key]
        public string IDEventoPerigoso { get; set; }

        [Display(Name ="Evento Perigoso Potencial")]
        public string Descricao { get; set; }


        

    }
}
