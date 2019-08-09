using Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder RunGestorCoreBusinessMigrations(this IApplicationBuilder applicationBuilder)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var logger = serviceScope.ServiceProvider.GetService<ILoggerFactory>().CreateLogger<CoreBusinessContext>();

                var sqlConfiguration = serviceScope.ServiceProvider.GetService<CoreBusinessSqlConfiguration>();
                if (sqlConfiguration.EnableMigrations)
                {
                    logger.LogInformation("Applying migrations for Gestor Core Business...");

                    using (var context = serviceScope.ServiceProvider.GetService<CoreBusinessContext>())
                        context.Database.Migrate();

                    logger.LogInformation("Gestor Core Business migrations applied.");
                }
                else
                    logger.LogInformation("Gestor Core Business migrations disabled.");
            }

            return applicationBuilder;
        }
    }
}