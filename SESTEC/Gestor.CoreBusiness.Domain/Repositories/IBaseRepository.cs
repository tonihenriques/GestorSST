using Gestor.Domain.Entities;
using System;
using System.Linq;

namespace Gestor.Domain.Repositories
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        IUnitOfWork UnitOfWork { get; }

        T ObterPeloId(Guid id);

        void Inserir(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        IQueryable<T> Consulta { get; } //TODO: analisar esse IQueryable porque ele é treta!
    }
}