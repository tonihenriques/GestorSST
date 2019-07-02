using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbPerigoPotencial")]
    public class PerigoPotencial : EntidadeBase
    {
        [Key]
        public string IDPerigoPotencial { get; set; }

        [Display(Name = "Evento Perigoso Potencial")]
        public string DescricaoEvento { get; set; }


    }
}
