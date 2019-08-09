using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.Networking.Abstractions;
using Gestor.RazorPages.RestClients.CoreBusiness;
using Gestor.RazorPages.RestClients.CoreBusiness.Empregados;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Gestor.RazorPages
{
    public class Startup : RootStartup
    {
        protected override ApplicationProfile ApplicationProfile => Configuration.TryGet<ApplicationProfile>();

        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        #region [+] Overrides
        protected override void AddCustomServicesAtTheBeginning(IServiceCollection services)
        {
        }

        protected override void AddCustomServicesAtTheEnd(IServiceCollection services)
        {
            var coreBusinessConfiguration = Configuration.TryGet<CoreBusinessConfiguration>();
            services.AddSingleton(coreBusinessConfiguration);
            services.AddTransient(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.Create(coreBusinessConfiguration.ApiUrl);

                return RestService.For<IEmpregadosClient>(httpClient);
            });
        }

        protected override void AddCustomMiddlewaresToTheBeginningOfThePipeline(IApplicationBuilder app)
        {
        }

        protected override void AddCustomMiddlewaresToTheEndOfThePipeline(IApplicationBuilder app)
        {
        }
        #endregion
    }    
}