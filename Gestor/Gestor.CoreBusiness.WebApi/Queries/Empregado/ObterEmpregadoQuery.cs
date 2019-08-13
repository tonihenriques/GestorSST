using MediatR;
using System;

namespace Gestor.CoreBusiness.WebApi.Queries.Empregado
{
    public class ObterEmpregadoQuery : IRequest<ObterEmpregadoQueryResult>
    {
        public Guid EmpregadoId { get; set; }
    }
}