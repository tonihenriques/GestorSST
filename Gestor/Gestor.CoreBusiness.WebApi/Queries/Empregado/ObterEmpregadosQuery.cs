using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using MediatR;

namespace Gestor.CoreBusiness.WebApi.Queries.Empregado
{
    public class ObterEmpregadosQuery : IRequest<ObterEmpregadosQueryResult>
    {
        public StatusEmpregado Status { get; set; } = StatusEmpregado.Livre;
        public int Quantidade { get; set; } = 100;
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}