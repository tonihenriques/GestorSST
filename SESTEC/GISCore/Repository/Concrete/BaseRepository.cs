using GISCore.Repository.Abstract;
using GISCore.Repository.Configuration;
using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {

        protected SESTECContext Context;

        public BaseRepository(SESTECContext contextParam)
        {
            Context = contextParam;
        }

        public void Inserir(T entidade)
        {
            entidade.DataInclusao = DateTime.Now;
            entidade.UsuarioInclusao = "LoginTeste";
            entidade.DataExclusao = DateTime.MaxValue;
            //entidade.ID = Guid.NewGuid().ToString();
            Context.Entry(entidade).State = EntityState.Added;
            Context.SaveChanges();
        }

        public void Alterar(T entidade)
        {
            
            //entidade.UsuarioExclusao = "Antonio Henriques";
            ///entidade.DataExclusao = DateTime.Now;
            Context.Entry(entidade).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Excluir(T entidade)
        {
            
            entidade.DataExclusao = DateTime.Now;
            Context.Entry(entidade).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public IQueryable<T> Consulta
        {
            get
            {
                return from c in Context.Set<T>() select c;
            }

        }
       
    }
}
