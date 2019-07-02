using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbPossiveisDanos")]
    public class PossiveisDanos: EntidadeBase
    {
        [Key]
        public string IDPossiveisDanos { get; set; }

        [Display(Name ="Possível Dano")]
        public string DescricaoDanos { get; set; }

    }
}
