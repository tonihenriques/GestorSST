using Gestor.Domain.Business;
using Gestor.Domain.ViewModels.Empregado;
using System;
using System.Web.Mvc;

namespace GISWeb.Controllers.v2
{
    public class EmpregadoController : Controller
    {
        private readonly IEmpregadoBusiness empregadoBusiness;

        public EmpregadoController(IEmpregadoBusiness empregadoBusiness)
        {
            this.empregadoBusiness = empregadoBusiness ?? throw new ArgumentNullException(nameof(empregadoBusiness));
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel)
        {
            try
            {
                empregadoBusiness.Cadastrar(cadastrarEmpregadoViewModel);

                return View();
            }
            catch (Exception e)
            {
                throw;
            }

            //if (!ModelState.IsValid)
            //    return Json(new { resultado = TratarRetornoValidacaoToJSON() });

            //try
            //{

            //    EmpregadoBusiness.Inserir(empregado);

            //    TempData["MensagemSucesso"] = "O empregado '" + empregado.Nome + "' foi cadastrado com sucesso.";

            //    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("ListaEmpregado", "Empregado", new { id = empregado.IDEmpregado }) } });
            //}
            //catch (Exception ex)
            //{
            //    if (ex.GetBaseException() == null)
            //    {
            //        return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
            //    }
            //    else
            //    {
            //        return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
            //    }
            //}
        }
    }
}