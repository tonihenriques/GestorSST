using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("Rel_AspectoPergunta")]
    public class AspectoPergunta:EntidadeBase
    {
        [Key]
        public string IDAspectoPergunta { get; set; }

        [Display(Name ="Aspecto")]
        public string idAspecto { get; set; }

        [Display(Name ="Pergunta")]
        public string idPergunta { get; set; }

        public virtual Aspecto Aspecto { get; set; }

        public virtual Pergunta Pergunta { get; set; }

    }
}
