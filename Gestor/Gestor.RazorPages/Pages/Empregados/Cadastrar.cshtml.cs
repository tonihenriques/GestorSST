using Furiza.AspNetCore.WebApp.Configuration;
using Gestor.RazorPages.RestClients.CoreBusiness.Empregados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Gestor.RazorPages.Pages.Empregados
{
    [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
    public class CadastrarModel : PageModel
    {
        private readonly IEmpregadosClient empregadosClient;

        [BindProperty]
        public EmpregadosPost EmpregadosPost { get; set; }

        [TempData]
        public string FeedbackSuccess { get; set; }

        public CadastrarModel(IEmpregadosClient empregadosClient)
        {
            this.empregadosClient = empregadosClient ?? throw new ArgumentNullException(nameof(empregadosClient));
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await empregadosClient.PostAsync(EmpregadosPost);

            FeedbackSuccess = $"O empregado <b>{result.Codigo}</b> foi cadastrado com êxito. <a href='{Url.Page($"/Empregados/Detalhar", new { id = result.Id.Value })}'>Clique aqui</a> para acessar sua página de detalhes.";

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Empregados/Cadastrar")
                });
        }
    }
}