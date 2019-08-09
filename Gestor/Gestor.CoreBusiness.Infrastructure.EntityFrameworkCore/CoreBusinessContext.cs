using Furiza.Base.Core.SeedWork;
using Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore.EntityConfigurations.EmpregadoAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore
{
    internal class CoreBusinessContext : DbContext, IUnitOfWork
    {
        public CoreBusinessContext(DbContextOptions<CoreBusinessContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpregadoEntityTypeConfiguration());
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