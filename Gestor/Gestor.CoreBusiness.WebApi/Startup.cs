using Furiza.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gestor.CoreBusiness.WebApi
{
    public class Startup : RootStartup
    {
        protected override ApiProfile ApiProfile => new ApiProfile()
        {
            Name = "GestorCoreBusinessApi",
            Description = "Gestor Core Business Web Api",
            DefaultVersion = "1.0",
            DefaultCultureInfo = "pt-BR"
        };

        public Startup(IConfiguration configuration) : base(configuration)
        {
            AutomapperAssemblies.Add(typeof(Startup).Assembly);
        }

        protected override void AddCustomServicesAtTheBeginning(IServiceCollection services)
        {
        }

        protected override void AddCustomServicesAtTheEnd(IServiceCollection services)
        {
            services.AddGestorCoreBusinessApplication();
            services.AddGestorCoreBusinessEntityFramework(Configuration.TryGet<Infrastructure.EntityFrameworkCore.CoreBusinessSqlConfiguration>());
            services.AddGestorCoreBusinessQueries(Configuration.TryGet<Queries.CoreBusinessSqlConfiguration>());
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {
        }

        protected override void AddCustomMiddlewaresToTheEndOfThePipeline(IApplicationBuilder app)
        {
            app.RunGestorCoreBusinessMigrations();
        }
    }
}