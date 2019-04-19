using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbCargo")]
    public class Cargo: EntidadeBase
    {
        [Key]
        public string IDCargo { get; set; }

        [Display(Name ="Nome do Cargo")]
        public string NomeDoCargo { get; set; }

        [Display(Name = "Diretoria")]
        [Required(ErrorMessage = "Selecione uma Diretoria")]
        public string IDDiretoria { get; set; }

        
        public virtual  Diretoria Diretoria { get; set; }

        //public virtual  ICollection<Funcao> Funcao { get; set; }

        //public virtual ICollection<Alocacao> Alocacao { get; set; }


    }
}
