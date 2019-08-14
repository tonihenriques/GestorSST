using Furiza.Base.Core.Domain.BR.ValueObjects;
using System;

namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public class EmpregadosGetResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public Cpf Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public StatusEmpregado? Status { get; set; }
    }
}