using MediatR;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGestorCoreBusinessQueries(this IServiceCollection services, CoreBusinessSqlConfiguration coreBusinessSqlConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(coreBusinessSqlConfiguration ?? throw new ArgumentNullException(nameof(coreBusinessSqlConfiguration)));
            services.AddTransient<CoreBusinessQueryContext>();

            services.AddMediatR(typeof(CoreBusinessQueryContext).Assembly);

            return services;
        }
    }
}