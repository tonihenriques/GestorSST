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
    public class CargoController : Controller
    {
        #region Inject

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        [Inject]
        public ICargoBusiness CargoBusiness { get; set; }

        [Inject]
        public IDiretoriaBusiness DiretoriaBusiness { get; set; }

        #endregion
        // GET: TipoDeRisco
        public ActionResult Index()
        {
            ViewBag.Cargo = CargoBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).Distinct().ToList();

            return View();
        }


        public ActionResult Novo()
        {


            ViewBag.Diretoria = new SelectList(DiretoriaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDDiretoria", "Sigla");
                
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cargo oCargo)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    CargoBusiness.Inserir(oCargo);

                    TempData["MensagemSucesso"] = "O Cargo '" + oCargo.NomeDoCargo + "' foi cadastrado com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Cargo", new { id = oCargo.IDCargo })}});

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

            return View(CargoBusiness.Consulta.FirstOrDefault(p => p.IDCargo.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Cargo oCargo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CargoBusiness.Alterar(oCargo);

                    TempData["MensagemSucesso"] = "O Cargo '" + oCargo.NomeDoCargo + "' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Cargo") } });
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
        public ActionResult TerminarComRedirect(string IDCargo)
        {

            try
            {
                Cargo oCargo = CargoBusiness.Consulta.FirstOrDefault(p => p.IDCargo.Equals(IDCargo));
                if (oCargo == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir este Cargo." } });
                }
                else
                {
                    oCargo.DataExclusao = DateTime.Now;
                    oCargo.UsuarioExclusao = "LoginTeste";
                    CargoBusiness.Alterar(oCargo);

                    TempData["MensagemSucesso"] = "O Cargo'" + oCargo.NomeDoCargo + "' foi excluido com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Cargo", new { id = IDCargo }) } });
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



    }
}