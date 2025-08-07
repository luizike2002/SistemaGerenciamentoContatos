﻿using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ControleDeContatos.Filters
{
    public class PaginaParaAdminLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            {
                string sessaoUsuario = context.HttpContext.Session.GetString("SessaoUsuarioLogado");
                if (string.IsNullOrEmpty(sessaoUsuario))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
                else
                {
                    UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
                    if (usuario == null)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                    }
                    else
                    {
                        if (usuario.Perfil != ControleDeContatos.Enums.PerfilEnum.Administrador)
                        {
                            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                        }
                    }
                  
                }
                base.OnActionExecuting(context);
            }
        }
    }
}