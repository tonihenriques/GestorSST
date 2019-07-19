using Gestor.Domain.Entities;
using Gestor.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Linq;

namespace Gestor.Infrastructure.EntityFramework.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {
        protected readonly GestorContext gestorContext;

        public IUnitOfWork UnitOfWork => gestorContext;

        public BaseRepository(GestorContext gestorContext)
        {
            this.gestorContext = gestorContext ?? throw new ArgumentNullException(nameof(gestorContext));
        }

        public IQueryable<T> Consulta => throw new NotImplementedException();

        public void Inserir(T entidade)
        {
            gestorContext.Entry(entidade).State = EntityState.Added;
        }

        public void Alterar(T entidade)
        {
            gestorContext.Entry(entidade).State = EntityState.Modified;
        }

        public void Excluir(T entidade)
        {
            gestorContext.Entry(entidade).State = EntityState.Deleted;
        }
    }
}