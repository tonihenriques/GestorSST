using Furiza.Base.Core.SeedWork;
using System;
using System.Collections.Generic;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore.Repositories
{
    internal abstract class BaseWriteOnlyRepository<E> where E : Entity
    {
        protected readonly CoreBusinessContext coreBusinessContext;

        protected BaseWriteOnlyRepository(CoreBusinessContext coreBusinessContext)
        {
            this.coreBusinessContext = coreBusinessContext ?? throw new ArgumentNullException(nameof(coreBusinessContext));
        }

        public void BatchInsert(IEnumerable<E> aggregates)
        {
            coreBusinessContext.Set<E>().AddRange(aggregates);
        }

        public void BatchUpdate(IEnumerable<E> aggregates)
        {
            coreBusinessContext.Set<E>().UpdateRange(aggregates);
        }

        public void Insert(E aggregate)
        {
            coreBusinessContext.Set<E>().Add(aggregate);
        }

        public void Update(E aggregate)
        {
            coreBusinessContext.Set<E>().Update(aggregate);
        }
    }
}