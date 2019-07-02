using GISCore.Business.Abstract;
using GISCore.Repository.Abstract;
using GISModel.Entidades;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Business.Concrete
{
    public class BaseBusiness<T> : IBaseBusiness<T> where T : EntidadeBase
    {

        [Inject]
        public IBaseRepository<T> Repository { get; set; }

        public virtual void Inserir(T entidade)
        {
            Repository.Inserir(entidade);
        }

        public virtual void Alterar(T entidade)
        {
            Repository.Alterar(entidade);
        }

        public virtual void Excluir(T entidade)
        {
            Repository.Excluir(entidade);
        }

        public virtual IQueryable<T> Consulta
        {
            get { return Repository.Consulta; }
        }

    }
}
