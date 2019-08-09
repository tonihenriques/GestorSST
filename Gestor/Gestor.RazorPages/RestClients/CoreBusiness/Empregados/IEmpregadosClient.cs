using Refit;
using System;
using System.Threading.Tasks;

namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public interface IEmpregadosClient
    {
        [Post("/api/v1/Empregados")]
        Task<PostResult> PostAsync(EmpregadosPost empregadosPost);

        [Put("/api/v1/Empregados/{id}")]
        Task PutAsync(Guid id, EmpregadosPut empregadosPut);
    }
}