using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.CoreBusiness.Domain.ViewModels.EmpregadoViewModels
{
    public class AtualizarEmpregadoViewModel
    {
        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime? DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Matricula { get; set; }
    }
}