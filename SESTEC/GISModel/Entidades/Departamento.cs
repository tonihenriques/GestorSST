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

    [Table("tbDepartamento")]
    public class Departamento : EntidadeBase
    {
        [Key]
        public string IDDepartamento { get; set; }

        [Required(ErrorMessage = "Informe o código do departamento")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Informe a sigla do departamento")]
        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public Situacao Status { get; set; }

        public virtual Empresa Empresa { get; set; }

        [Display(Name = "Empresa")]        
        public string IDEmpresa { get; set; }

        //[Display(Name = "Departamento Vinculado")]
        //public string DepartamentoVinculado { get; set; }


        [Display(Name = "Diretoria")]        
        public string IDDiretoria { get; set; }

        public virtual Diretoria Diretoria { get; set; }

        //public virtual ICollection<Alocacao> Alocacao { get; set; }

        //public virtual ICollection<Estabelecimento> Estabelecimento { get; set; }





    }
}
