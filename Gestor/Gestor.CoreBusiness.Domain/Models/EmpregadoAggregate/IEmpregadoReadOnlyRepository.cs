using Furiza.Base.Core.Domain.BR.ValueObjects;
using Furiza.Base.Core.SeedWork;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate
{
    public interface IEmpregadoReadOnlyRepository : IAggregateReadOnlyRepository<Empregado>
    {
        Task<Empregado> ObterPeloCpfAsync(Cpf cpf);
    }
}