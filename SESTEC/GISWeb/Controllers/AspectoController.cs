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
    public class AspectoController : Controller
    {

        #region

        [Inject]
        public IEquipeBusiness EquipeBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }


        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }


        [Inject]
        public IAspectoBusiness AspectoBusiness { get; set; }

        #endregion


        // GET: Aspecto
        public ActionResult Index()
        {

            ViewBag.Aspecto = AspectoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();


            return View();

        }



        public ActionResult Novo()
        {

            ViewBag.Aspecto = AspectoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aspecto oAspecto)
        {

            if (ModelState.IsValid)
                try
                {

                    AspectoBusiness.Inserir(oAspecto);

                    TempData["MensagemSucesso"] = "O Aspecto '" + oAspecto.DescricaoAspecto + "' foi cadastrada com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Aspecto", new { id = oAspecto.DescricaoAspecto }) } });



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
            else
            {
                return Json(new { resultado = TratarRetornoValidacaoToJSON() });

            }



        }

        public ActionResult Edicao(string id)
        {
            ViewBag.Aspecto = AspectoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
            
            ViewBag.Aspecto = id;

            return View(AspectoBusiness.Consulta.FirstOrDefault(p => p.IDAspecto.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Aspecto oAspecto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AspectoBusiness.Alterar(oAspecto);

                    TempData["MensagemSucesso"] = "O Aspecto '" + oAspecto.DescricaoAspecto + "' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Aspecto") } });
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


        [HttpPost]
        public ActionResult Terminar(string IDAspecto)
        {
            try
            {
                Aspecto oAspecto = AspectoBusiness.Consulta.FirstOrDefault(p => p.IDAspecto.Equals(IDAspecto));
                if (oAspecto == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o Aspecto!" } });
                }
                else
                {
                    oAspecto.UsuarioExclusao = "LoginTeste";
                    AspectoBusiness.Alterar(oAspecto);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O Aspecto '" + oAspecto.DescricaoAspecto + "' foi excluído com sucesso!" } });
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

                throw;
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