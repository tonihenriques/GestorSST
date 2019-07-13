using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbPergunta")]
    public class Pergunta: EntidadeBase
    {
        [Key]
        public string IDPergunta { get; set; }

        [Display(Name = "Item")]
        public string Item { get; set; }

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

    }
}
