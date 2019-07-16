using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.ViewModels.Empregado
{
    public class CadastrarEmpregadoViewModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        //[CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        //public string Imagem { get; set; }

        //[Required(ErrorMessage = "O sexo é obrigatório")]
        //public Sexo? Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do empregado")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }
    }
}