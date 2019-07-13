using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbAspecto")]
    public class Aspecto:EntidadeBase
    {
        [Key]
        public string IDAspecto { get; set; }

        [Display(Name = "Descriçao")]
        public string DescricaoAspecto { get; set; }

        

    }
}
