using Gestor.RazorPages.RestClients.CoreBusiness.Empregados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;

namespace Gestor.RazorPages.Pages.Empregados
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IEmpregadosClient empregadosClient;

        [BindProperty]
        public EmpregadosGetMany EmpregadosGetMany { get; set; }

        public IndexModel(IEmpregadosClient empregadosClient)
        {
            this.empregadosClient = empregadosClient ?? throw new ArgumentNullException(nameof(empregadosClient));
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostEmpregadosPartialAsync()
        {
            var empregadosGetManyResult = await empregadosClient.GetAsync(EmpregadosGetMany);

            return new PartialViewResult()
            {
                ViewName = "_EmpregadosPartial",
                ViewData = new ViewDataDictionary<EmpregadosGetManyResult>(ViewData, empregadosGetManyResult)
            };
        }
    }
}