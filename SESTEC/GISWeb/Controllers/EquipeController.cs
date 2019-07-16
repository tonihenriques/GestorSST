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

    public class EquipeController : Controller
    {

        #region

        [Inject]
        public IEquipeBusiness EquipeBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }


        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }


        #endregion


        // GET: Equipe
        public ActionResult Index()
        {

            ViewBag.Equipe = EquipeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();


            return View();

        }



        public ActionResult Novo()
        {

            ViewBag.Equipe = EquipeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
            ViewBag.Departamento = new SelectList(DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDDepartamento", "Sigla");
            ViewBag.Empresa = new SelectList(EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDempresa", "NomeFantasia");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Equipe oEquipe)
        {

            if (ModelState.IsValid)
                try
                {

                    EquipeBusiness.Inserir(oEquipe);

                    TempData["MensagemSucesso"] = "A equipe '" + oEquipe.NomeDaEquipe + "' foi cadastrada com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Equipe", new { id = oEquipe.NomeDaEquipe }) } });



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
            ViewBag.Equipe = EquipeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();
            ViewBag.Departamento = new SelectList(DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDDepartamento", "Sigla");
            ViewBag.Empresa = new SelectList(EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)), "IDempresa", "NomeFantasia");
            ViewBag.IDEquipe = id;

            return View(EquipeBusiness.Consulta.FirstOrDefault(p => p.IDEquipe.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Equipe oEquipe)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EquipeBusiness.Alterar(oEquipe);

                    TempData["MensagemSucesso"] = "O Equipe '" + oEquipe.NomeDaEquipe + "' foi atualizada com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Equipe") } });
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
        public ActionResult Terminar(string IDEquipe)
        {
            try
            {
                Equipe oEquipe = EquipeBusiness.Consulta.FirstOrDefault(p => p.IDEquipe.Equals(IDEquipe));


                if (oEquipe == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir a Equipe!" } });
                }
                else
                {
                    oEquipe.UsuarioExclusao = "LoginTeste";
                    EquipeBusiness.Alterar(oEquipe);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "A equipe '" + oEquipe.NomeDaEquipe + "' foi excluída com sucesso!" } });
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