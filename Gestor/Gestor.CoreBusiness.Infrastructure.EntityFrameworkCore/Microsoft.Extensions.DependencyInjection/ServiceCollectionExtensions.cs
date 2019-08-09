using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore;
using Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGestorCoreBusinessEntityFramework(this IServiceCollection services, CoreBusinessSqlConfiguration coreBusinessSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(coreBusinessSqlConfiguration ?? throw new ArgumentNullException(nameof(coreBusinessSqlConfiguration)));

            services.AddDbContext<CoreBusinessContext>(options => options.UseSqlServer(coreBusinessSqlConfiguration.ConnectionString));

            services.AddScoped<IEmpregadoReadOnlyRepository, EmpregadoRepository>();
            services.AddScoped<IEmpregadoWriteOnlyRepository, EmpregadoRepository>();

            return services;
        }
    }
}