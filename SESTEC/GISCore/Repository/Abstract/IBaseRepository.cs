using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Repository.Abstract
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {

        void Inserir(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        IQueryable<T> Consulta { get; }

    }
}
