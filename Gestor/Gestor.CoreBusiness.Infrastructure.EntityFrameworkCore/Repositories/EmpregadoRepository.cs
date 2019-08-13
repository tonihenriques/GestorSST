using Furiza.Base.Core.Domain.BR.ValueObjects;
using Furiza.Base.Core.SeedWork;
using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore.Repositories
{
    internal class EmpregadoRepository : BaseWriteOnlyRepository<Empregado>, IEmpregadoReadOnlyRepository, IEmpregadoWriteOnlyRepository
    {
        public IUnitOfWork UnitOfWork => coreBusinessContext;

        public EmpregadoRepository(CoreBusinessContext coreBusinessContext) : base(coreBusinessContext)
        {
        }

        public Empregado GetById(Guid id)
        {
            var empregado = coreBusinessContext.Find<Empregado>(id);
            if (empregado != null)
            {
                //coreBusinessContext.Entry(empregado).Collection(i => i.Membros).Load();
                //coreBusinessContext.Entry(empregado).Reference(i => i.Cpf).Load();
            }

            return empregado;
        }

        public async Task<Empregado> GetByIdAsync(Guid id)
        {
            var empregado = await coreBusinessContext.FindAsync<Empregado>(id);
            if (empregado != null)
            {
                //await coreBusinessContext.Entry(empregado).Collection(i => i.Membros).LoadAsync();
                //await coreBusinessContext.Entry(empregado).Reference(i => i.Cpf).LoadAsync();
            }

            return empregado;
        }

        public async Task<Empregado> ObterPeloCpfAsync(Cpf cpf)
        {
            var empregado = await coreBusinessContext.Set<Empregado>().SingleOrDefaultAsync(e => e.Cpf == cpf);
            if (empregado != null)
            {
                //await coreBusinessContext.Entry(empregado).Collection(i => i.Membros).LoadAsync();
                //await coreBusinessContext.Entry(empregado).Reference(i => i.Cpf).LoadAsync();
            }

            return empregado;
        }
    }
}