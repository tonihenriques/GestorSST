﻿using GISCore.Business.Abstract;
using GISModel.DTO.Shared;
using GISModel.Entidades;
using GISWeb.Infraestrutura.Filters;
using GISWeb.Infraestrutura.Provider.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GISWeb.Controllers
{
    public class UsuarioController : BaseController
    {

        #region Inject

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IUsuarioBusiness UsuarioBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }

        [Inject]
        public ICustomAuthorizationProvider CustomAuthorizationProvider { get; set; }

        #endregion

        [MenuAtivo(MenuAtivo = "Administracao/Usuarios")]
        public ActionResult Index()
        {
            //ViewBag.Usuarios = UsuarioBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).OrderBy(o => o.Nome).ToList();
            ViewBag.Usuarios = (from usr in UsuarioBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                join emp in EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList() on usr.IDEmpresa equals emp.IDEmpresa
                                join dep in DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList() on usr.IDDepartamento equals dep.IDDepartamento
                                select new Usuario()
                                {
                                    IDUsuario = usr.IDUsuario,
                                    Nome = usr.Nome,
                                    Login = usr.Login,
                                    CPF = usr.CPF,
                                    Email = usr.Email
                                }).ToList();

            return View();
        }

        [MenuAtivo(MenuAtivo = "Administracao/Usuarios")]
        public ActionResult Novo()
        {
            ViewBag.Empresas = EmpresaBusiness.Consulta.Where(a => string.IsNullOrEmpty(a.UsuarioExclusao)).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool bRedirect = false;
                    if (Usuario.IDUsuario != null && Usuario.IDUsuario.Equals("redirect"))
                        bRedirect = true;

                    //Usuario.UsuarioInclusao = CustomAuthorizationProvider.UsuarioAutenticado.Login;
                    Usuario.UsuarioInclusao = "Teste";
                    UsuarioBusiness.Inserir(Usuario);

                    if (bRedirect)
                    {
                        TempData["MensagemSucesso"] = "O usuário '" + Usuario.Nome + "' foi cadastrado com sucesso.";
                        return Json(new { resultado = new RetornoJSON() { URL = "#" + Url.Action("Index", "Usuario").Substring(1) } });
                    }
                    else
                    {
                        return Json(new { resultado = new RetornoJSON() { Sucesso = "O usuário '" + Usuario.Nome + "' foi cadastrado com sucesso." } });
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
            else
            {
                return Json(new { resultado = TratarRetornoValidacaoToJSON() });
            }
        }

        [MenuAtivo(MenuAtivo = "Administracao/Usuarios")]
        public ActionResult Edicao(string id)
        {
            ViewBag.Empresas = EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();

            List<Usuario> usuarios = (from usr in UsuarioBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDUsuario.Equals(id)).ToList()
                                      join emp in EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList() on usr.IDEmpresa equals emp.IDEmpresa
                                      join dep in DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList() on usr.IDDepartamento equals dep.IDDepartamento
                                      select new Usuario()
                                      {
                                          IDUsuario = usr.IDUsuario,
                                          Nome = usr.Nome,
                                          Login = usr.Login,
                                          CPF = usr.CPF,
                                          Email = usr.Email,
                                          TipoDeAcesso = usr.TipoDeAcesso,
                                          DataInclusao = usr.DataInclusao
                                      }).ToList();

            if (usuarios.Count > 0)
            {
                Usuario oUsuario = usuarios[0];
                ViewBag.Departamentos = DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDEmpresa.Equals(oUsuario.IDEmpresa)).ToList();
                return PartialView(oUsuario);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Login;
                    UsuarioBusiness.Alterar(Usuario);

                    TempData["MensagemSucesso"] = "O usuário '" + Usuario.Nome + "' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = "#" + Url.Action("Index", "Usuario").Substring(1) } });
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

        public ActionResult BuscarUsuarioPorID(string IDUsuario)
        {
            try
            {
                //Usuario oUsuario = UsuarioBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.UniqueKey.Equals(IDUsuario));

                List<Usuario> usuarios = (from usr in UsuarioBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDUsuario.Equals(IDUsuario)).ToList()
                                          join emp in EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList() on usr.IDEmpresa equals emp.IDEmpresa
                                          join dep in DepartamentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList() on usr.IDDepartamento equals dep.IDDepartamento
                                          select new Usuario()
                                          {
                                              IDUsuario = usr.IDUsuario,
                                              Nome = usr.Nome,
                                              Login = usr.Login,
                                              CPF = usr.CPF,
                                              Email = usr.Email,
                                              TipoDeAcesso = usr.TipoDeAcesso,
                                              DataInclusao = usr.DataInclusao,
                                          }).ToList();

                if (usuarios.Count < 1)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Usuário com o ID '" + IDUsuario + "' não encontrado." } });
                }
                else
                {
                    Usuario oUsuario = usuarios[0];
                    return Json(new { data = RenderRazorViewToString("_Detalhes", oUsuario) });
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
        public ActionResult Terminar(string IDUsuario)
        {

            try
            {
                Usuario oUsuario = UsuarioBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDUsuario.Equals(IDUsuario));
                if (oUsuario == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o usuário, pois o mesmo não foi localizado." } });
                }
                else
                {

                    oUsuario.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Login;
                    //UsuarioBusiness.Terminar(oUsuario);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O usuário '" + oUsuario.Nome + "' foi excluído com sucesso." } });
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
        public ActionResult TerminarComRedirect(string IDUsuario)
        {

            try
            {
                Usuario oUsuario = UsuarioBusiness.Consulta.FirstOrDefault(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDUsuario.Equals(IDUsuario));
                if (oUsuario == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o usuário, pois o mesmo não foi localizado." } });
                }
                else
                {
                    oUsuario.DataExclusao = DateTime.Now;
                    oUsuario.UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Login;

                    UsuarioBusiness.Alterar(oUsuario);

                    TempData["MensagemSucesso"] = "O usuário '" + oUsuario.Nome + "' foi excluído com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = "#" + Url.Action("Index", "Empresa").Substring(1) } });
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

    
    }
}