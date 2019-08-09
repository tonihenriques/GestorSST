using Gestor.CoreBusiness.Application.Business;
using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGestorCoreBusinessApplication(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IEmpregadoBusiness, EmpregadoBusiness>();

            return services;
        }
    }
}