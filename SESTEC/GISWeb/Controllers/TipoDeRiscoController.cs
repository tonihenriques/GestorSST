using GISCore.Business.Abstract;
using GISCore.Business.Concrete;
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
    
    public class TipoDeRiscoController : Controller
    {
        
        #region Inject

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        [Inject]
        public IEventoPerigosoBusiness EventoPerigosoBusiness { get; set; }


        [Inject]
        public IPossiveisDanosBusiness PossiveisDanosBusiness { get; set; }

        [Inject]
        public IPerigoPotencialBusiness PerigoPotencialBusiness { get; set; }

        [Inject]
        public IAtividadesDoEstabelecimentoBusiness AtividadesDoEstabelecimentoBusiness { get; set; }

        [Inject]
        public IAtividadeBusiness AtividadeBusiness { get; set; }

        //[Inject]
        //public IMedidaControleRiscoFuncaoBusiness MedidaControleRiscoFuncaoBusiness { get; set; }

        #endregion
        // GET: TipoDeRisco
        public ActionResult Index()
        {
            ViewBag.Riscos = TipoDeRiscoBusiness.Consulta.Where(d=>string.IsNullOrEmpty(d.UsuarioExclusao)).ToList();

            return View();
        }




        //parametros(IDAtividadesDoEstabelecimento,Nome do Estabelecimento,IDAtividade)
        public ActionResult Novo(string id, string Nome, string Ativida)
        {
            ViewBag.EventoPerigoso = new SelectList(EventoPerigosoBusiness.Consulta.ToList(), "IDEventoPerigoso", "Descricao");
            ViewBag.PossiveisDanos = new SelectList(PossiveisDanosBusiness.Consulta.ToList(), "IDPossiveisDanos", "DescricaoDanos");
            ViewBag.EventPeriPotencial = new SelectList(PerigoPotencialBusiness.Consulta.ToList(), "IDPerigoPotencial", "DescricaoEvento");
            ViewBag.AtivEstabelecimento = new SelectList(AtividadesDoEstabelecimentoBusiness.Consulta.ToList(), "IDAtividadesDoEstabelecimento", "DescricaoDestaAtividade");
            ViewBag.idAtividadeEstabel = id;
            ViewBag.Nome = Nome;
            ViewBag.Ativiade = Ativida;

            List<TipoDeRisco> Riscos = (from Tip in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        join ATE in AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idAtividadesDoEstabelecimento equals ATE.IDAtividadesDoEstabelecimento
                                        join PD in PossiveisDanosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idPossiveisDanos equals PD.IDPossiveisDanos
                                        join PP in PerigoPotencialBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idPerigoPotencial equals PP.IDPerigoPotencial
                                        join EP in EventoPerigosoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idEventoPerigoso equals EP.IDEventoPerigoso
                                        where ATE.IDAtividadesDoEstabelecimento.Equals(id)
                                        select new TipoDeRisco()
                                        {
                                            IDTipoDeRisco = Tip.IDTipoDeRisco,
                                            EClasseDoRisco = Tip.EClasseDoRisco,
                                            FonteGeradora = Tip.FonteGeradora,
                                            Tragetoria = Tip.Tragetoria,
                                            PossiveisDanos = new PossiveisDanos()
                                            {
                                                DescricaoDanos = PD.DescricaoDanos,

                                            },
                                            PerigoPotencial = new PerigoPotencial()
                                            {
                                                DescricaoEvento = PP.DescricaoEvento,
                                            },
                                            EventoPerigoso = new EventoPerigoso()
                                            {
                                                Descricao = EP.Descricao,
                                            },
                                            AtividadesDoEstabelecimento = new AtividadesDoEstabelecimento()
                                            {
                                                IDAtividadesDoEstabelecimento = ATE.IDAtividadesDoEstabelecimento
                                            }



                                        }


                                        ).ToList();

            ViewBag.DescricaoRiscos = Riscos;


            return View();
        }


        //parametro(IDAtividade)
        public ActionResult NovoRisco(string idAtividade, string Descricao, string AtivId, string NomeFuncao, string Diretoria, string NomeDiretoria)
        {
            ViewBag.EventoPerigoso = new SelectList(EventoPerigosoBusiness.Consulta.Where(p=>string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDEventoPerigoso", "Descricao");
            ViewBag.PossiveisDanos = new SelectList(PossiveisDanosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDPossiveisDanos", "DescricaoDanos");
            ViewBag.EventPeriPotencial = new SelectList(PerigoPotencialBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDPerigoPotencial", "DescricaoEvento");
            ViewBag.AtivEstabelecimento = new SelectList(AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDAtividadesDoEstabelecimento", "DescricaoDestaAtividade");
            ViewBag.Descricao = Descricao;
            ViewBag.Nome = NomeFuncao;
            ViewBag.Ativiade = idAtividade;
            ViewBag.AtivId = AtivId;
            ViewBag.Diretoria = Diretoria;
            ViewBag.NomeDiretoria = NomeDiretoria;
            TempData["Funcao"] = NomeFuncao;




            List<TipoDeRisco> Riscos = (from Tip in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        join AT in AtividadeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idAtividade equals AT.IDAtividade
                                        join PD in PossiveisDanosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idPossiveisDanos equals PD.IDPossiveisDanos
                                        join PP in PerigoPotencialBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idPerigoPotencial equals PP.IDPerigoPotencial
                                        join EP in EventoPerigosoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                        on Tip.idEventoPerigoso equals EP.IDEventoPerigoso
                                        where AT.IDAtividade.Equals(idAtividade)
                                        select new TipoDeRisco()
                                        {
                                            IDTipoDeRisco = Tip.IDTipoDeRisco,
                                            EClasseDoRisco = Tip.EClasseDoRisco,
                                            FonteGeradora = Tip.FonteGeradora,
                                            Tragetoria = Tip.Tragetoria,
                                            PossiveisDanos = new PossiveisDanos()
                                            {
                                                DescricaoDanos = PD.DescricaoDanos,

                                            },
                                            PerigoPotencial = new PerigoPotencial()
                                            {
                                                DescricaoEvento = PP.DescricaoEvento,
                                            },
                                            EventoPerigoso = new EventoPerigoso()
                                            {
                                                Descricao = EP.Descricao,
                                            },
                                            Atividade = new Atividade()
                                            {
                                                
                                                IDAtividade = AT.IDAtividade,
                                                Descricao =AT.Descricao
                                            }



                                        }


                                        ).ToList();

            ViewBag.DescricaoRiscos = Riscos;


            var AtividadeList =  AtividadeBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDAtividade.Equals(idAtividade)));

            ViewBag.ListaAtividade = AtividadeList;


            try
            {

                //var oTipoR = from c in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                //                        select new TipoDeRisco() {
                //                            IDTipoDeRisco = c.IDTipoDeRisco,
                //                            Tragetoria = c.Tragetoria,
                //                            FonteGeradora = c.FonteGeradora,

                //                            PossiveisDanos = new PossiveisDanos()
                //                            {
                //                                DescricaoDanos = c.PossiveisDanos.DescricaoDanos

                //                            },
                //                            PerigoPotencial = new PerigoPotencial()
                //                            {
                //                                DescricaoEvento = c.PerigoPotencial.DescricaoEvento
                //                            },
                //                            EventoPerigoso = new EventoPerigoso()
                //                            {
                //                                Descricao = c.EventoPerigoso.Descricao
                //                            }

                //                        };

                TipoDeRisco oTipoRiscos = new TipoDeRisco();

                //TipoDeRisco oTipoRiscos = TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao));


                //Atividade oIDAtividade = AtividadeBusiness.Consulta.FirstOrDefault(p => p.IDAtividade.Equals(idAtividade));


                //var oIDRiscosDoEstabelecimento = ViewBag.Imagens;

                if (oTipoRiscos == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Tipos não encontrado." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_NovosRiscos", oTipoRiscos) });
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

        //Começa a quebrar a partir daqui - nome da função chega quebrado aqui
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarNovoRisco(TipoDeRisco oTipoDeRisco, string idAtividade, string Nome, string AtivId, string NomeFuncao, string Diretoria, string NomeDiretoria)
        {

            
            

            if (ModelState.IsValid)
            {

                try
                {
                    AtividadesDoEstabelecimento oAtividadesDoEstabelecimento = AtividadesDoEstabelecimentoBusiness.Consulta.FirstOrDefault(p => p.IDAtividadesDoEstabelecimento.Equals(idAtividade));

                    oTipoDeRisco.idAtividade = idAtividade;
                    TipoDeRiscoBusiness.Inserir(oTipoDeRisco);

                   



                    TempData["MensagemSucesso"] = "O Risco foi cadastrado com sucesso!";
                    //id funçao, nome da funçao, id da Diretoria, nome da diretoria
                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Novo", "Atividade", new { id= AtivId, nome= NomeFuncao, idDiretoria= Diretoria, nomeDiretoria= NomeDiretoria }) } });

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
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TipoDeRisco oTipoDeRisco, string idAtividadeEstabel)
        {


            
            if (ModelState.IsValid)
            {

                try
                {
                    AtividadesDoEstabelecimento oAtividadesDoEstabelecimento = AtividadesDoEstabelecimentoBusiness.Consulta.FirstOrDefault(p => p.IDAtividadesDoEstabelecimento.Equals(idAtividadeEstabel));

                    oTipoDeRisco.idAtividadesDoEstabelecimento = idAtividadeEstabel;
                    TipoDeRiscoBusiness.Inserir(oTipoDeRisco);

                    TempData["MensagemSucesso"] = "O Risco foi cadastrado com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Novo", "TipoDeRisco" , new { id = idAtividadeEstabel, Nome = oAtividadesDoEstabelecimento.Estabelecimento.NomeCompleto, Ativida = oAtividadesDoEstabelecimento.DescricaoDestaAtividade })  } });

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
            //ViewBag.Riscos = TipoDeRiscoBusiness.Consulta.Where(p => p.IDTipoDeRisco.Equals(id));

            return View(TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(TipoDeRisco oTipoDeRisco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoDeRiscoBusiness.Alterar(oTipoDeRisco);

                    TempData["MensagemSucesso"] = "O Tipo de Risco foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "TipoDeRisco") } });
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



        public ActionResult Excluir(string id)
        {
            ViewBag.Riscos = new SelectList(TipoDeRiscoBusiness.Consulta.ToList(), "IDTipoDeRisco", "DescricaoDoRisco");
            return View(TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(id)));

        }



        [HttpPost]
        public ActionResult Terminar(string IDTipodeRisco)
        {

            try
            {
                TipoDeRisco oTipoDeRisco = TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(IDTipodeRisco));
                if (oTipoDeRisco == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o Risco, pois o mesmo não foi localizado." } });
                }
                else
                {

                    oTipoDeRisco.DataExclusao = DateTime.Now;
                    oTipoDeRisco.UsuarioExclusao = "LoginTeste";
                    TipoDeRiscoBusiness.Alterar(oTipoDeRisco);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O risco foi excluído com sucesso." } });
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
