using GISModel.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GISModel.Enums;

namespace GISModel.Entidades
{

    [Table("tbEmpregado")]
    public class Empregado : EntidadeBase
    {
        [Key]
        public string IDEmpregado { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        //public string Imagem { get; set; }

        //[Required(ErrorMessage = "O sexo é obrigatório")]
        //public Sexo? Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do empregado")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }

        public string Endereco { get; set; }

        public bool Admitido { get; set; }


        //public ICollection<Admissao> Admissao { get; set; }

        //public string Telefone { get; set; }

        //[Display(Name = "Tipo de Empregado")]
        //[Required(ErrorMessage = "Informe o tipo do empregado")]
        //public TipoEmpregado? TipoEmpregado { get; set; }

        //[Display(Name = "Empresa")]
        //public string IDEmpresa { get; set; }

        //[Display(Name ="Departamento")]
        //public string IDDepartamento { get; set; }


        //public virtual Empresa Empresa { get; set; }


        //public Departamento Departamento { get; set; }

    }
}
