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
    public class PerguntaController : Controller
    {

        #region

        [Inject]
        public IEquipeBusiness EquipeBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }


        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IPerguntaBusiness PerguntaBusiness { get; set; }

        #endregion


        // GET: Pergunta
        public ActionResult Index()
        {

            ViewBag.Pergunta = PerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();


            return View();

        }



        public ActionResult Novo()
        {

            ViewBag.Pergunta = PerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Pergunta oPergunta)
        {

            if (ModelState.IsValid)
                try
                {

                    PerguntaBusiness.Inserir(oPergunta);

                    TempData["MensagemSucesso"] = "A Pergunta '" + oPergunta.Descricao + "' foi cadastrada com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Pergunta", new { id = oPergunta.Descricao }) } });



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
            ViewBag.Pergunta = PerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
           
            ViewBag.IDPergunta = id;

            return View(PerguntaBusiness.Consulta.FirstOrDefault(p => p.IDPergunta.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Pergunta oPergunta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PerguntaBusiness.Alterar(oPergunta);

                    TempData["MensagemSucesso"] = "A Pergunta '" + oPergunta.Descricao + "' foi atualizada com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Pergunta") } });
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
        public ActionResult Terminar(string IDPergunta)
        {
            try
            {
                Pergunta oPergunta = PerguntaBusiness.Consulta.FirstOrDefault(p => p.IDPergunta.Equals(IDPergunta));
                if (oPergunta == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir a Pergunta!" } });
                }
                else
                {
                    oPergunta.UsuarioExclusao = "LoginTeste";
                    PerguntaBusiness.Alterar(oPergunta);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "A Pergunta '" + oPergunta.Descricao + "' foi excluída com sucesso!" } });
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
