﻿using GISCore.Business.Abstract;
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
    public class DocsPorAtividadeController : Controller
    {
        #region Inject


        [Inject]
        public IDocsPorAtividadeBusiness DocsPorAtividadeBusiness { get; set; }


        [Inject]
        public IDocumentosPessoalBusiness DocumentosPessoalBusiness { get; set; }

        [Inject]
        public IDiretoriaBusiness DiretoriaBusiness { get; set; }

        [Inject]
        public IAtividadeBusiness AtividadeBusiness { get; set; }


        [Inject]
        public IFuncaoBusiness FuncaoBusiness { get; set; }

        //[Inject]
        //public IAtividadeRiscosBusiness AtividadeRiscosBusiness { get; set; }

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        #endregion
        // GET: TipoDeRisco
        public ActionResult Index()
        {

            ViewBag.Atividade = AtividadeBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).ToList();

            return View();
        }

        public ActionResult Novo(string id)
        {


            ViewBag.Documentos = new SelectList(DocumentosPessoalBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDDocumentosEmpregado", "NomeDocumento");
           
            ViewBag.IDAtividade = AtividadeBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)&&(d.IDAtividade.Equals(id))).ToList(); ;
            ViewBag.idAtiv = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(DocsPorAtividade oDocAtividade, string idAtiv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    oDocAtividade.idAtividade = idAtiv;
                    DocsPorAtividadeBusiness.Inserir(oDocAtividade);

                    TempData["MensagemSucesso"] = "O Documento foi cadastrado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "DocsPorAtividade") } });
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

            return View(DocumentosPessoalBusiness.Consulta.FirstOrDefault(p => p.IDDocumentosEmpregado.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(DocumentosPessoal oDocumentosPessoalBusiness)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DocumentosPessoalBusiness.Alterar(oDocumentosPessoalBusiness);

                    TempData["MensagemSucesso"] = "O Documento '" + oDocumentosPessoalBusiness.NomeDocumento + "' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "DocumentosPessoal") } });
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
        public ActionResult TerminarComRedirect(string IDDocumentosEmpregado, string NomeDocumento)
        {

            try
            {
                DocumentosPessoal oDocumentosPessoal = DocumentosPessoalBusiness.Consulta.FirstOrDefault(p => p.IDDocumentosEmpregado.Equals(IDDocumentosEmpregado));
                if (oDocumentosPessoal == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir este Documento." } });
                }
                else
                {
                    oDocumentosPessoal.DataExclusao = DateTime.Now;
                    oDocumentosPessoal.UsuarioExclusao = "LoginTeste";
                    DocumentosPessoalBusiness.Alterar(oDocumentosPessoal);

                    TempData["MensagemSucesso"] = "O Documento foi excluido com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "DocumentosPessoal") } });
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