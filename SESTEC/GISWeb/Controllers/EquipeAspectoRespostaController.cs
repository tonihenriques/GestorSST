using GISCore.Business.Abstract;
using GISCore.Business.Concrete;
using GISModel.DTO.Shared;
using GISModel.Entidades;
using GISWeb.Infraestrutura.Filters;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GISWeb.Controllers
{
    public class EquipeAspectoRespostaController : Controller
    {
        #region

        [Inject]
        public IEquipeBusiness EquipeBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }


        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IEquipeAspectoRespostaBusiness EquipeAspectoRespostaBusiness { get; set; }

        [Inject]
        public IAspectoPerguntaBusiness AspectoPerguntaBusiness { get; set; }


        #endregion




        // GET: EquipeAspectoResposta
        public ActionResult Index()
        {
            ViewBag.Equipe = EquipeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();




            return View();
        }

        public ActionResult Novo(string idEquipe, string nome)
        {

            try
            {
                ViewBag.Pergunta = AspectoPerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
                //List<AspectoPergunta> oAspectoPergunta = AspectoPerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

               

                if (ViewBag.Pergunta == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Não é possível fazer este cadastro!" } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_Resposta", ViewBag.Pergunta) });
                }
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException() == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
                }
                else
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
                }
            }
        }
        [HttpPost]
        public ActionResult Cadastrar()
        {




            return View();
        }


        private string RenderRazorViewToString(string viewName, object model = null)
        {
            ViewData.Model = model;
            using (var sw = new System.IO.StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public RetornoJSON TratarRetornoValidacaoToJSON()
        {

            string msgAlerta = string.Empty;
            foreach (ModelState item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    foreach (System.Web.Mvc.ModelError i in item.Errors)
                    {
                        msgAlerta += i.ErrorMessage;
                    }
                }
            }

            return new RetornoJSON()
            {
                Alerta = msgAlerta,
                Erro = string.Empty,
                Sucesso = string.Empty
            };

        }
    }
}