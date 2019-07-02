using GISCore.Business.Abstract;
using GISCore.Repository.Configuration;
using GISModel.DTO.Shared;
using GISModel.Entidades;
using GISModel.Enums;
using GISWeb.Infraestrutura.Filters;
//using GISWeb.Infraestrutura.Provider.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GISWeb.Controllers
{

    
    public class EmpregadoController : Controller
    {
        private SESTECContext db = new SESTECContext();
        #region Inject

        //[Inject]
        //public IMedidaControleRiscoFuncaoBusiness MedidaControleRiscoFuncaoBusiness { get; set; }

        [Inject]
        public IAtividadesDoEstabelecimentoBusiness AtividadesDoEstabelecimentoBusiness { get; set; }

        //[Inject]
        //public IAtividadeBusiness AtividadeBusiness { get; set; }

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        [Inject]
        public IEmpregadoBusiness EmpregadoBusiness { get; set; }

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }
                

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }

        //[Inject]
        //public IAlocacaoBusiness AlocacaoBusiness { get; set; }

        //[Inject]
        //public IAdmissaoBusiness AdmissaoBusiness { get; set; }

        //[Inject]
        //public IAtividadeRiscosBusiness AtividadeRiscosBusiness { get; set; }

        [Inject]
        public IEstabelecimentoAmbienteBusiness EstabelecimentoAmbienteBusiness { get; set; }
        [Inject]
        public IEstabelecimentoBusiness EstabelecimentoBusiness { get; set; }

        [Inject]
        public IPossiveisDanosBusiness PossiveisDanosBusiness { get; set; }

        [Inject]
        public IEventoPerigosoBusiness EventoPerigosoBusiness { get; set; }

        //[Inject]
        //public IFuncaoBusiness FuncaoBusiness { get; set; }

        #endregion


        // public ActionResult Index()
        // {
        // ViewBag.Admissao = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

        //ViewBag.Admissao = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

        //ViewBag.Empregado = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

        //var AdmissaoEmpregado 
        //List<Alocacao> oAlocacao = (from a in AlocacaoBusiness.Consulta.ToList()
        //                           join b in AdmissaoBusiness.Consulta.ToList()
        //                           on a.IdAdmissao equals b.IDAdmissao
        //                           join c in EmpregadoBusiness.Consulta.ToList()
        //                           on b.IDEmpregado equals c.IDEmpregado                                       
        //                           select new Alocacao()
        //                           {                                                                              

        //                              IDAlocacao = a.IDAlocacao,

        //                               Admissao =new Admissao()
        //                              {
        //                                  IDAdmissao = b.IDAdmissao,

        //                                  Empregado = new Empregado()
        //                                  {

        //                                   IDEmpregado = c.IDEmpregado,
        //                                   Nome = c.Nome,
        //                                   CPF =c.CPF,
        //                                   Email = c.Email
        //                                  },

        //                              }


        //                           }).ToList();


        //ViewBag.Alocacao = oAlocacao;



        //List<Admissao> oAdmissao = (from a in AdmissaoBusiness.Consulta.ToList()                                       
        //                           join b in EmpregadoBusiness.Consulta.ToList()
        //                           on a.IDEmpregado equals b.IDEmpregado
        //                           //group a by a.IdAdmissao into Admis
        //                           select new Admissao()
        //                           {
        //                               //AdmisID = Admis.Key                                           

        //                               IDAdmissao = a.IDAdmissao,

        //                               Empregado = new Empregado()
        //                               {
        //                                       IDEmpregado = b.IDEmpregado,                                                  
        //                                       Nome = b.Nome,
        //                                       CPF = b.CPF,
        //                                       Email = b.Email
        //                               }


        //                           }).ToList();


        //ViewBag.Admissao = oAdmissao;


        //var listaEmpregado = (from a in AdmissaoBusiness.Consulta.ToList()
        //                      join b in AlocacaoBusiness.Consulta.ToList()
        //                      on a.IDAdmissao equals b.IdAdmissao
        //                      join c in EmpregadoBusiness.Consulta.ToList()
        //                      on a.IDEmpregado equals c.IDEmpregado
        //                      select new
        //                      {
        //                          oIDAdmissao = a.IDAdmissao,
        //                          oIDlocacao = b.IDAlocacao,
        //                          oNome = c.Nome,
        //                          oCPF = c.CPF,
        //                          oEmail = c.Email,


        //                      }

        //                      ).ToList();

        //ViewBag.ListEmpregado = listaEmpregado;





        //var listaDeEmpregado = (from a in EmpregadoBusiness.Consulta.ToList()
        //                        join b in AdmissaoBusiness.Consulta.ToList()
        //                        on a.IDEmpregado equals b.IDEmpregado
        //                        //join c in AlocacaoBusiness.Consulta.ToList()
        //                        //on b.IDAdmissao equals c.IdAdmissao
        //                        where a.IDEmpregado.Equals(b.IDEmpregado)
        //                        group b by b.IDAdmissao into IDAmissao
        //                        select new
        //                        {

        //                            AdmID2 = IDAmissao.Key

        //                        }).OrderBy(p => p.AdmID2);


        //List<string> filtro2 = new List<string>();
        //foreach (var item in listaDeEmpregado)
        //{
        //    filtro2.Add(item.AdmID2);
        //}

        //List<Admissao> model2 =
        //    AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao))
        //    .Where(p => filtro2.Contains(p.IDAdmissao))
        //    .OrderBy(p => p.IDAdmissao)
        //    .ToList();
        //ViewBag.ListaEmpregado = model2;




        //var lista = (from a in AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //             join b in EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //             on a.IDEmpregado equals b.IDEmpregado
        //             join c in AlocacaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //             on a.IDAdmissao equals c.IdAdmissao


        //             select new
        //             {

        //                 AdmissaoID = a.IDAdmissao,
        //                 EmpCPF = b.CPF,
        //                 EmpEmail = b.Email,
        //                 EmpNome = b.Nome



        //             }


        //             ).ToList();

        //ViewBag.Lista = lista;







        //return View();
        //}


        //public ActionResult BuscarDetalhesDeMedidasDeControle(string IDMedidasDeControleRiscoFuncao)
        //{

        //ViewBag.MedidasDeControleRiscoFuncao = MedidaControleRiscoFuncaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDMedidasDeControleRiscoFuncao.Equals(IDMedidasDeControleRiscoFuncao))).ToList();

        //try
        //{
        //    MedidasControleRiscoFuncao oMedidasControleRiscoFuncao = MedidaControleRiscoFuncaoBusiness.Consulta.FirstOrDefault(p => p.IDMedidasDeControleRiscoFuncao.Equals(IDMedidasDeControleRiscoFuncao));
        //    if (oMedidasControleRiscoFuncao == null)
        //    {
        //        return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens não encontrada." } });
        //    }
        //    else
        //    {
        //        return Json(new { data = RenderRazorViewToString("_BuscarDetalhesEmpregado", oMedidasControleRiscoFuncao) });
        //    }
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




        // }



        //public ActionResult BuscarDetalhesEmpregado(string idEmpregado)        
        //{

        //ViewBag.Empregado = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(idEmpregado))).ToList();
        //ViewBag.Alocacao = AlocacaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.Admissao.IDEmpregado.Equals(idEmpregado))).OrderBy(p => p.Ativado.Equals("Ativado")).ToList();

        //var AtividadeRiscos = (from a in AtividadeRiscosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                       join b in AtividadeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                       on a.IdAtividade equals b.IDAtividade
        //                       join c in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                       on a.IdTipoDeRisco equals c.IDTipoDeRisco
        //                       join d in PossiveisDanosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                       on c.idPossiveisDanos equals d.IDPossiveisDanos
        //                       join e in EventoPerigosoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                       on c.idEventoPerigoso equals e.IDEventoPerigoso
        //                       join f in FuncaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                       on b.idFuncao equals f.IDFuncao
        //                       where b.idFuncao.Equals(f.IDFuncao)
        //                       group a by a.IDAtividadeRiscos into g
        //                       select new
        //                       {

        //                           lista = g.Key

        //                       }
        //     ).ToList();
        //List<string> Filtro = new List<string>();
        //foreach(var listagem in AtividadeRiscos)
        //{
        //    Filtro.Add(listagem.lista);
        //}
        //List<AtividadeRiscos> model01 = AtividadeRiscosBusiness.Consulta.Where(p => Filtro.Contains(p.IDAtividadeRiscos)).ToList();


        //ViewBag.AtividadeRisco = model01;




        //    var ListaEstabelecimentoAmbiente =
        //        (from w in AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //         join a in EstabelecimentoAmbienteBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //         on w.IDEstabelecimentoImagens equals a.IDEstabelecimentoImagens
        //         join b in EstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //         on a.IDEstabelecimento equals b.IDEstabelecimento
        //         join c in DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //         on b.IDDepartamento equals c.IDDepartamento
        //         join d in AlocacaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //         on b.IDEstabelecimento equals d.idEstabelecimento
        //         where w.IDEstabelecimentoImagens.Equals(a.IDEstabelecimentoImagens)
        //         //group a by a.IDEstabelecimentoImagens into g
        //         select new AtividadesDoEstabelecimento()
        //         {

        //             //lista = g.Key,

        //             IDAtividadesDoEstabelecimento = w.IDAtividadesDoEstabelecimento,
        //             IDEstabelecimentoImagens = a.IDEstabelecimentoImagens,

        //             EstabelecimentoImagens = new EstabelecimentoAmbiente()
        //             {

        //                 IDEstabelecimentoImagens = a.IDEstabelecimentoImagens,
        //                 ResumoDoLocal = a.ResumoDoLocal,

        //                 Estabelecimento = new Estabelecimento()
        //                 {

        //                     IDEstabelecimento = b.IDEstabelecimento,
        //                     NomeCompleto = b.NomeCompleto


        //                 }

        //             },


        //         }

        //        ).ToList();

        //    List<string> filtro = new List<string>();

        //    foreach (var iten in ListaEstabelecimentoAmbiente)
        //    {
        //        filtro.Add(iten.IDAtividadesDoEstabelecimento);
        //    }

        //    List<AtividadesDoEstabelecimento> model = AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => filtro.Contains(p.IDAtividadesDoEstabelecimento)).ToList();

        //    ViewBag.ListaEstabelecimentoAmbiente = model;


        //    try
        //    {
        //        Admissao oIDAdmissao = AdmissaoBusiness.Consulta.FirstOrDefault(p => p.IDEmpregado.Equals(idEmpregado));
        //        if (oIDAdmissao == null)
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens não encontrada." } });
        //        }
        //        else
        //        {
        //            return Json(new { data = RenderRazorViewToString("_Detalhes", oIDAdmissao) });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.GetBaseException() == null)
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
        //        }
        //        else
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
        //        }
        //    }





        //}



        //public ActionResult BuscarEmpregado()
        //{

        //    var EmpregadoSemAdmissao = (from a in db.Empregado
        //                                join b in db.Admissao
        //                                on a.IDEmpregado equals b.IDEmpregado

        //                                group a by a.IDEmpregado into Emp


        //                                select new
        //                                {
        //                                    EmpID = Emp.Key,



        //                             }).OrderByDescending(p => p.EmpID);

        //    List<string> filtro = new List<string>();
        //    foreach (var item in EmpregadoSemAdmissao)
        //    {
        //        filtro.Add(item.EmpID);
        //    }

        //    List<Empregado> model =
        //        db.Empregado
        //        .Where(p => filtro.Contains(p.IDEmpregado))               
        //        .OrderBy(p => p.IDEmpregado)
        //        .ToList();




        //    ViewBag.Empregado = model;


        //    ViewBag.Admissao = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

        //    //ViewBag.Empregado = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

        //    return View();
        //}

        //public ActionResult Lista()
        //{

        //    ViewBag.ListaEmpregado = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
        //    return View();

        //}

        public ActionResult ListaEmpregado(string id)
        {

            //if (id != null)
            //{

                ViewBag.Empregado = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(id))).ToList();

            //}
            //else
            //{
            //    List<Empregado> Admissao =
            //        (from a in AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
            //         join b in EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
            //         on a.IDEmpregado equals b.IDEmpregado
            //         select new Empregado()
            //         {
            //             IDEmpregado = b.IDEmpregado,
            //             Nome = b.Nome


            //         }

            //          ).ToList();

            //    List<string> filtro = new List<string>();

            //    foreach (var item in Admissao)
            //    {
            //        filtro.Add(item.IDEmpregado);
            //    }

            //    var Adm = filtro;

            //    List<Empregado> NotAdmissao =
            //       (from a in AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
            //        join b in EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
            //        on a.IDEmpregado equals b.IDEmpregado
            //        where !Adm.Contains(a.IDEmpregado)
            //        select new Empregado()
            //        {
            //            IDEmpregado = b.IDEmpregado,
            //            Nome = b.Nome


            //        }

                    // ).ToList();

               // ViewBag.Empregado = NotAdmissao;

            //}


            return View();
        }


        //public ActionResult EmpregadosSemAdmissao()
        //{
        //    //Implementar codigo aqui








        //    return View();

        //}


        public ActionResult Novo()
        {
            return View();
        }


        public ActionResult Edicao(string id)
        {
            
            return View(EmpregadoBusiness.Consulta.FirstOrDefault(p => p.IDEmpregado.Equals(id)));
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    EmpregadoBusiness.Inserir(empregado);

                    TempData["MensagemSucesso"] = "O empregado '" + empregado.Nome + "' foi cadastrado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("ListaEmpregado", "Empregado",new {id=empregado.IDEmpregado }) } });
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
        public ActionResult Atualizar(Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //empregado.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login;
                    EmpregadoBusiness.Alterar(empregado);

                    TempData["MensagemSucesso"] = "O empregado '" + empregado.Nome + "' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Empregado") } });
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
        public ActionResult Terminar(string IDEmpregado)
        {

            try
            {
                Empregado oEmpregado = EmpregadoBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDEmpregado.Equals(IDEmpregado));
                if (oEmpregado == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o empregado, pois o mesmo não foi localizado." } });
                }
                else
                {
                    oEmpregado.DataExclusao = DateTime.Now;
                    //oEmpregado.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login;
                    EmpregadoBusiness.Excluir(oEmpregado);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O empregado '" + oEmpregado.Nome + "' foi excluído com sucesso." } });
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

        //[HttpPost]
        //public ActionResult BuscarEmpregados(string idTipoEmpregado)
        //{
        //    if (string.IsNullOrEmpty(idTipoEmpregado))
        //        ViewBag.Empregados = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
        //    else
        //    {
        //        if ((int)TipoEmpregado.Próprio == Convert.ToInt16(idTipoEmpregado))
        //        ViewBag.Empregados = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.TipoEmpregado == (TipoEmpregado.Próprio)).ToList();
        //        else
        //        ViewBag.Empregados = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.TipoEmpregado == (TipoEmpregado.Terceirizado)).ToList();
        //    }

        //    return PartialView("_Empregados");
        //}


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