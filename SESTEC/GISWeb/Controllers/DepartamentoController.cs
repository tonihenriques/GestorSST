using GISCore.Business.Abstract;
using GISModel.DTO.Departamento;
using GISModel.DTO.Shared;
using GISModel.Entidades;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GISWeb.Controllers
{
    public class DepartamentoController : Controller
    {

        #region Inject

        [Inject]
        public IDiretoriaBusiness DiretoriaBusiness { get; set; }

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }

           
        #endregion

        public ActionResult Index()
        {
            ViewBag.Departamentos = DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
            return View();
        }


        public ActionResult Novo(string IDEmpresa, string nome)
        {
            ViewBag.Diretoria = new SelectList(DiretoriaBusiness.Consulta.Where(p=>string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDDiretoria", "Sigla");
            ViewBag.Empresas = IDEmpresa;
            ViewBag.NomeEmpresa = nome;
            
            //ViewBag.Empresas = new SelectList(EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDEmpresa", "NomeFantasia");
            

            try
            {
                // Atividade oAtividade = AtividadeBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.idFuncao.Equals(id));

                if (ViewBag.Empresas == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Parametro id não passado." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_Novo") });
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


        public ActionResult ListarDepartamentosPorEmpresa(string idEmpresa) {

            return Json(new { resultado = DepartamentoBusiness.Consulta.Where(p => p.IDEmpresa.Equals(idEmpresa)).ToList().OrderBy(p=>p.Sigla) });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Departamento Departamento, string IDDiretoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Departamento.IDDiretoria = IDDiretoria;
                    DepartamentoBusiness.Inserir(Departamento);

                    TempData["MensagemSucesso"] = "O departamento '" + Departamento.Sigla + "' foi cadastrado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("EmpresaCriacoes", "Empresa", new { id = Departamento.IDEmpresa }) } });
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
            else
            {
                return Json(new { resultado = TratarRetornoValidacaoToJSON() });
            }
        }

        public ActionResult Edicao(string id)
        {
            ViewBag.Empresa = new SelectList(EmpresaBusiness.Consulta.ToList(), "IDEmpresa", "NomeFantasia");
            return View(DepartamentoBusiness.Consulta.FirstOrDefault(p => p.IDDepartamento.Equals(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Departamento Departamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepartamentoBusiness.Alterar(Departamento);

                    TempData["MensagemSucesso"] = "O departamento '" + Departamento.Sigla + "' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Departamento") } });
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
            else
            {
                return Json(new { resultado = TratarRetornoValidacaoToJSON() });
            }
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

        public ActionResult Excluir(string id)
        {
            ViewBag.Empresa = new SelectList(EmpresaBusiness.Consulta.ToList(), "IDEmpresa", "NomeFantasia");
            return View(DepartamentoBusiness.Consulta.FirstOrDefault(p => p.IDDepartamento.Equals(id)));
           
        }



        [HttpPost]
        public ActionResult Excluir(Departamento oDepartamento)
        {

            try
            {
                
                if (oDepartamento == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o Departamento, pois o mesmo não foi localizado." } });
                }
                else
                {

                    //oDepartamento.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login;
                    // oDepartamento.UKUsuarioDemissao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login;

                    oDepartamento.UsuarioExclusao = "Antonio Henriques";
                    oDepartamento.DataExclusao = DateTime.Now;
                    DepartamentoBusiness.Excluir(oDepartamento);

                    TempData["MensagemSucesso"] = "O departamento '" + oDepartamento.Sigla + "' foi excluido com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Departamento") } });
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



        public ActionResult DepartamentoDiretoria(string IDDiretoria, string Sigla)
        {
            ViewBag.Sigla = Sigla;
            ViewBag.Departamento = DepartamentoBusiness.Consulta.Where(p => p.IDDiretoria.Equals(IDDiretoria));

            try
            {
                Departamento oIDepartamento = DepartamentoBusiness.Consulta.FirstOrDefault(p => p.IDDiretoria.Equals(IDDiretoria));
                if (oIDepartamento == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Lista não encontrada." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_Detalhes", oIDepartamento) });
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


            //return View();
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
                        if (!string.IsNullOrEmpty(i.ErrorMessage))
                            msgAlerta += i.ErrorMessage;
                        else
                            msgAlerta += i.Exception.Message;
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