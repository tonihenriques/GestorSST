using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using System;

namespace Gestor.CoreBusiness.WebApi.Queries.Empregado
{
    public class ObterEmpregadoQueryResult
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public StatusEmpregado? Status { get; set; }

        //TODO: adicionar depois as colunas da admissão e alocação atuais do empregado
    }
}