using Gestor.Domain.Entities;
using Gestor.Domain.Repositories;
using Gestor.Infrastructure.EntityFramework.EntityConfigurations;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Gestor.Infrastructure.EntityFramework
{
    internal class GestorContext : DbContext, IUnitOfWork
    {
        public DbSet<Empregado> Empregados { get; set; }

        public GestorContext() : base("SESTECConection") //TODO: parametrizar
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpregadoEntityTypeConfiguration());
        }

        public int SaveEntities()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveEntitiesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}