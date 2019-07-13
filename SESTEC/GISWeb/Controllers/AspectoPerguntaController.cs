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
    public class AspectoPerguntaController : Controller
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

        [Inject]
        public IAspectoPerguntaBusiness AspectoPerguntaBusiness { get; set; }

        [Inject]
        public IPerguntaBusiness PerguntaBusiness { get; set; }


        #endregion


        // GET: AspectoPergunta
        public ActionResult Index()
        {

            ViewBag.AspectoPergunta = AspectoPerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();


            return View();

        }



        public ActionResult Novo()
        {

            ViewBag.Pergunta =  new SelectList(PerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)),"IDPergunta","Descricao");
            ViewBag.Aspecto = new SelectList(AspectoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDAspecto", "DescricaoAspecto");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AspectoPergunta oAspectoPergunta)
        {

            if (ModelState.IsValid)
                try
                {

                    AspectoPerguntaBusiness.Inserir(oAspectoPergunta);

                    TempData["MensagemSucesso"] = "O AspectoPergunta foi cadastrado com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "AspectoPergunta", new { id = oAspectoPergunta.IDAspectoPergunta }) } });



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
            ViewBag.Pergunta = new SelectList(PerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDPergunta", "Descricao");
            ViewBag.Aspecto = new SelectList(AspectoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDAspecto", "DescricaoAspecto");

            ViewBag.IDAspecto = id;

            return View(AspectoPerguntaBusiness.Consulta.FirstOrDefault(p => p.IDAspectoPergunta.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(AspectoPergunta oAspectoPergunta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AspectoPerguntaBusiness.Alterar(oAspectoPergunta);

                    TempData["MensagemSucesso"] = "O AspectoPergunta foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "AspectoPergunta") } });
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
        public ActionResult Terminar(string IDAspectoPergunta)
        {
            try
            {
                AspectoPergunta oAspectoPergunta = AspectoPerguntaBusiness.Consulta.FirstOrDefault(p => p.IDAspectoPergunta.Equals(IDAspectoPergunta));
                if (oAspectoPergunta == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o AspectoPergunta!" } });
                }
                else
                {
                    oAspectoPergunta.UsuarioExclusao = "LoginTeste";
                    AspectoPerguntaBusiness.Alterar(oAspectoPergunta);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O AspectoPergunta '" + oAspectoPergunta.Pergunta.Descricao + "' foi excluído com sucesso!" } });
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