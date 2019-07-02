using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbFuncao")]
    public class Funcao: EntidadeBase
    {
        [Key]
        public string IDFuncao { get; set; }

        [Display(Name ="Nome da Função")]
        public string NomeDaFuncao { get; set; }

        [Display(Name ="Cargo")]
        public string IdCargo { get; set; }

        public virtual Cargo Cargo { get; set; }

        //public virtual ICollection<Atividade> Atividade { get; set; }
    }
}
