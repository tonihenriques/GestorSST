using Gestor.Domain.Entities;
using Gestor.Domain.Repositories;
using System;
using System.Linq;

namespace Gestor.Infrastructure.EntityFramework.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {
        public IQueryable<T> Consulta => throw new NotImplementedException();

        public void Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
