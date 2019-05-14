﻿using GISCore.Business.Abstract;
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
    public class AtividadeFuncaoLiberadaController : Controller
    {
        [Inject]
        public IAtividadesDoEstabelecimentoBusiness AtividadesDoEstabelecimentoBusiness { get; set; }

        [Inject]
        public IAtividadeFuncaoLiberadaBusiness AtividadeFuncaoLiberadaBusiness { get; set; }

        [Inject]
        public IAtividadeAlocadaBusiness AtividadeAlocadaBusiness { get; set; }


        // GET: AtividadeAlocada
        public ActionResult Novo(string id)
        {

            ViewBag.AtiviEstab = new SelectList(AtividadesDoEstabelecimentoBusiness.Consulta, "IDAtividadesDoEstabelecimento", "DescricaoDestaAtividade");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AtividadesDoEstabelecimento oAtividadesDoEstabelecimentoBusiness, string IDAtividadesDoEstabelecimento)
        {

            oAtividadesDoEstabelecimentoBusiness.IDAtividadesDoEstabelecimento = IDAtividadesDoEstabelecimento;
            //oMedidasDeControleExistentes.IDAtividadeRiscos = AtivRiscoID;

            if (ModelState.IsValid)
            {
                try
                {

                    AtividadesDoEstabelecimentoBusiness.Inserir(oAtividadesDoEstabelecimentoBusiness);

                    TempData["MensagemSucesso"] = "A imagem '" + oAtividadesDoEstabelecimentoBusiness.NomeDaImagem + "'foi cadastrada com sucesso.";


                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Novo", "MedidasDeControle", new { id = oAtividadesDoEstabelecimentoBusiness.IDAtividadesDoEstabelecimento }) } });
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
        public ActionResult SalvarAtividade(bool Acao, string idAtividade, string idAlocacao)
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                if (Acao)
                {
                    //Incluir vinculo entre Atividade e Alocação
                    if (idAlocacao.Contains("|"))
                    {
                        foreach (string item in idAlocacao.Split('|'))
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                AtividadeFuncaoLiberadaBusiness.Inserir(new AtividadeFuncaoLiberada()
                                {
                                    IDAlocacao = item,
                                    IDAtividade = idAtividade,
                                    //UsuarioInclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                                });
                            }
                        }
                    }
                    else
                    {
                        AtividadeFuncaoLiberadaBusiness.Inserir(new AtividadeFuncaoLiberada()
                        {
                            IDAlocacao = idAlocacao,
                            IDAtividade = idAtividade,
                            //UsuarioInclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                        });
                    }
                }
                else
                {
                    //Remover vinculo entre Menu e Perfil
                    if (idAlocacao.Contains("|"))
                    {
                        foreach (string item in idAlocacao.Split('|'))
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                AtividadeFuncaoLiberadaBusiness.Alterar(new AtividadeFuncaoLiberada()
                                {

                                    IDAlocacao = item,
                                    IDAtividade = idAtividade,
                                    DataExclusao = DateTime.Now,
                                    //UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                                });
                            }
                        }
                    }
                    else
                    {

                        AtividadeFuncaoLiberadaBusiness.Alterar(new AtividadeFuncaoLiberada()
                        {

                            IDAlocacao = idAlocacao,
                            IDAtividade = idAtividade,
                            DataExclusao = DateTime.Now,
                            UsuarioExclusao = "LoginTeste"
                            //UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                        });
                    }
                }

                return Json(new { resultado = new RetornoJSON() { } });
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
