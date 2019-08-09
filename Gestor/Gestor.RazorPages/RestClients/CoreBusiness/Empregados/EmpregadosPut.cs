using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public class EmpregadosPut
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