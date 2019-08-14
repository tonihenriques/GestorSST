using Refit;
using System;
using System.Threading.Tasks;

namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public interface IEmpregadosClient
    {
        [Get("/api/v1/Empregados")]
        Task<EmpregadosGetManyResult> GetAsync();

        [Get("/api/v1/Empregados")]
        Task<EmpregadosGetManyResult> GetAsync(EmpregadosGetMany empregadosGetMany);

        [Get("/api/v1/Empregados/{id}")]
        Task<EmpregadosGetResult> GetAsync(Guid id);

        [Post("/api/v1/Empregados")]
        Task<PostResult> PostAsync(EmpregadosPost empregadosPost);

        [Put("/api/v1/Empregados/{id}")]
        Task PutAsync(Guid id, EmpregadosPut empregadosPut);
    }
}