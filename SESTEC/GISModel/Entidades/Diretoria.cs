using GISModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{

    [Table("tbDiretoria")]
    public class Diretoria : EntidadeBase
    {
        [Key]
        public string IDDiretoria { get; set; }

        [Required(ErrorMessage = "Informe o código da Diretoria")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Informe a sigla da Diretoria")]
        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public Situacao Status { get; set; }

        
        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Selecione uma empresa")]
        public string IDEmpresa { get; set; }
       
        public virtual Empresa Empresa { get; set; }


    }
}
