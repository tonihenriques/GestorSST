using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore
{
    internal class CoreBusinessContextFactory : IDesignTimeDbContextFactory<CoreBusinessContext>
    {
        public CoreBusinessContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CoreBusinessContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GestorCoreBusiness;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(CoreBusinessContext).GetTypeInfo().Assembly.GetName().Name));

            return new CoreBusinessContext(builder.Options);
        }
    }
}