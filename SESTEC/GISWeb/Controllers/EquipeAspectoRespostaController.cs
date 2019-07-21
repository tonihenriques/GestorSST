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
using GISModel.DTO.QuestionarioPssicossocial;
using System.Data;
using GISHelpers.Utils;
using GISModel.Enums;
using GISWeb.Infraestrutura.Provider.Abstract;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web.SessionState;


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

        [Inject]
        public IPerguntaBusiness PerguntaBusiness { get; set; }

        [Inject]
        public IAspectoBusiness AspectoBusiness { get; set; }



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
                ViewBag.idEquipe = idEquipe;                   

                

                if (ViewBag.Pergunta == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Não é possível fazer este cadastro!" } });
                }
                else
                {
                    //string sql = @"select top 1 IDPergunta, Descricao
                    //               from tbPergunta
                    //               where IDPergunta not in (
                    //         select ap.idPergunta
                    //         from tbEquipe e, Rel_EquipeAspectoResposta ear, Rel_AspectoPergunta ap
                    //         where NomeDaEquipe = 'Equipe Rocket' and
                    //      e.IDEquipe = ear.idEquipe and
                    //      ear.idAspectoPergunta = ap.IDAspectoPergunta)";

                    var Query = (from P in AspectoPerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                 
                                 select new VMRespostas()
                                 {
                                      idEquipe = idEquipe,
                                      idPergunta = P.Pergunta.IDPergunta,
                                      Pergunta  =  P.Aspecto.DescricaoAspecto,
                                      Descricao = P.Pergunta.Descricao,
                                      idAspectoPergunta = P.IDAspectoPergunta

                                 });
                    

                    var Pergunta =            
                            (from EQ in EquipeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                            join EA in EquipeAspectoRespostaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                            on EQ.IDEquipe equals EA.idEquipe
                            join AP in AspectoPerguntaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                            on EA.idAspectoPergunta equals AP.IDAspectoPergunta
                            //join A in AspectoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                            //on EA.idAspecto equals A.IDAspecto
                            into EQGroup
                            from item in EQGroup.DefaultIfEmpty()                                                                                 
                            where EQ.IDEquipe.Equals(idEquipe)
                                select new VMRespostas()
                                {
                                    idEquipe = EQ.IDEquipe,
                                    Equipe = EQ.NomeDaEquipe,
                                    idPergunta = item.Pergunta.IDPergunta,
                                    idAspectoPergunta = item.IDAspectoPergunta,
                                    Pergunta = item.Aspecto.DescricaoAspecto,
                                    Descricao = item.Pergunta.Descricao


                                }).ToList();

                    var lRespostas = Pergunta.Count();
                    ViewBag.Contar = lRespostas;
                    ViewBag.Pergunta = Pergunta.ToList();
                    

                    ViewBag.Query = Query;

                    ViewBag.Query01 = Query.Take(1);

                    List<VMRespostas> Filtro = new List<VMRespostas>();

                    foreach (var item2 in Query)
                    {
                                            
                    foreach(var item in Pergunta)
                    {

                       if(item2.idPergunta != item.idPergunta && item.idEquipe.Equals(idEquipe))
                            {
                                Filtro.Add(item2);
                            }
                           
                    }
                    };

                    ViewBag.Filtro = Filtro.Take(1);
                    ViewBag.Resposta = Pergunta.ToList(); 





                    return Json(new { data = RenderRazorViewToString("_Resposta", lRespostas) });
                    


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
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(EquipeAspectoResposta oEquipeAspectoResposta)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    EquipeAspectoRespostaBusiness.Inserir(oEquipeAspectoResposta);

                    TempData["MensagemSucesso"] = "A Resposta foi cadastrada com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "EquipeAspectoResposta") } });
                    //, new { id = oEquipeAspectoResposta.idEquipe }) } });

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