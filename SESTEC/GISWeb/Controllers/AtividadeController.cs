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
    public class AtividadeController : Controller
    {
        #region Inject

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
            ViewBag.Atividade = AtividadeBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).OrderBy(d=>d.idFuncao).ToList();

            return View();
        }

        //recebe parametro de Funcao/index e listaFuncao para listar atividades relacionadas a função
        public ActionResult ListaAtividadePorFuncao(string IDFuncao, string NomeFuncao)
        {

            ViewBag.Funcao = NomeFuncao;

            ViewBag.ListaAtividadeFuncao = AtividadeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.idFuncao.Equals(IDFuncao)).OrderBy(p=>p.Descricao).ToList();

            try
            {
                // Atividade oAtividade = AtividadeBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.idFuncao.Equals(id));

                if (ViewBag.ListaAtividadeFuncao == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens4 não encontrada." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_Detalhes") });
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


        //parametro id da função, nome da função e id da Diretoria, passados de index/função e ListaFunção
        public ActionResult Novo(string id, string nome, string idDiretoria, string nomeDiretoria)
        {
            
            ViewBag.AtivId = id;

            ViewBag.NomeFuncao = nome;

            ViewBag.NomeDiretoria = nomeDiretoria;

            ViewBag.Atividade = FuncaoBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao) && (d.IDFuncao.Equals(id))).ToList();

            ViewBag.Diretoria = idDiretoria;

            ViewBag.AtividadeTotal = AtividadeBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao) && (d.idFuncao.Equals(id))).Count();

            List<Atividade> Ativ = (from a in FuncaoBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).ToList()
                                    join b in AtividadeBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).ToList()
                                    on a.IDFuncao equals b.idFuncao
                                    //join c in AtividadeRiscosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                    //on b.IDAtividade equals c.IdAtividade
                                    //join d in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                   // on c.IdTipoDeRisco equals d.IDTipoDeRisco
                                    where a.IDFuncao.Equals(id)
                                    select new Atividade()
                                    {
                                        Descricao = b.Descricao,

                                        Funcao = new Funcao()
                                        {
                                            NomeDaFuncao = a.NomeDaFuncao,
                                            IdCargo = a.IdCargo

                                        },

                                        //TipoDeRisco = new TipoDeRisco()
                                        //{
                                        //    DescricaoDoRisco = d.DescricaoDoRisco

                                        //}
                                        

                                    }

                                  ).ToList();
            ViewBag.FuncaoCargo = Ativ;




            //List<TipoDeRisco> TipoRiscos = (from a in FuncaoBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).ToList()
            //                                join b in AtividadeBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).ToList()
            //                                on a.IDFuncao equals b.idFuncao
            //                                join c in AtividadeRiscosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
            //                                on b.IDAtividade equals c.IdAtividade
            //                                join d in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
            //                                 on c.IdTipoDeRisco equals d.IDTipoDeRisco
            //                                where a.IDFuncao.Equals(id)
            //                                select new TipoDeRisco()
            //                                {

            //                                        IDTipoDeRisco = d.IDTipoDeRisco,
            //                                        DescricaoDoRisco = d.DescricaoDoRisco
                                                    

            //                                }

            //                      ).ToList();

            //ViewBag.TiposDeRiscos = TipoRiscos;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Atividade oAtividade, string AtivId)
        {
            oAtividade.idFuncao = AtivId;
            if (ModelState.IsValid)
            {
                try
                {
                    AtividadeBusiness.Inserir(oAtividade);

                    TempData["MensagemSucesso"] = "A Atividade '" + oAtividade.Descricao + "' foi cadastrada com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Atividade") } });

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

            return View(AtividadeBusiness.Consulta.FirstOrDefault(p => p.IDAtividade.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Atividade oAtividadeDeRisco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AtividadeBusiness.Alterar(oAtividadeDeRisco);

                    TempData["MensagemSucesso"] = "A Atividade '" + oAtividadeDeRisco.Descricao + "' foi atualizada com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "AtividadeDeRisco") } });
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
            //ViewBag.Cargo = new SelectList(CargoBusiness.Consulta.ToList(), "IDCargo", "NomeDoCargo");
            return View(AtividadeBusiness.Consulta.FirstOrDefault(p => p.IDAtividade.Equals(id)));

        }



        [HttpPost]
        public ActionResult Excluir(Atividade oAtividadeDeRisco)
        {

            try
            {

                if (oAtividadeDeRisco == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir a Atividade, pois a mesma não foi localizada." } });
                }
                else
                {

                    //oDepartamento.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login;
                    // oDepartamento.UKUsuarioDemissao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login;

                    oAtividadeDeRisco.UsuarioExclusao = "Antonio Henriques";
                    oAtividadeDeRisco.DataExclusao = DateTime.Now;
                    AtividadeBusiness.Excluir(oAtividadeDeRisco);

                    TempData["MensagemSucesso"] = "A Atividade '" + oAtividadeDeRisco.Descricao + "' foi excluida com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "AtividadeDeRisco") } });
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

        [RestritoAAjax]
        public ActionResult _Upload()
        {
            try
            {
                return PartialView("_Upload");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(ex.Message, "text/html");
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





    }
}