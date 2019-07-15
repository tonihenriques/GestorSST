using Gestor.Domain.Entities;
using System.Linq;

namespace Gestor.Domain.Repositories
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        void Inserir(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        IQueryable<T> Consulta { get; } //TODO: analisar esse IQueryable porque ele é treta!
    }
}