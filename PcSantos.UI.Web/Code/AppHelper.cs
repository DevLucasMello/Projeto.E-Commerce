using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace PcSantos.UI.Web
{
    public static class AppHelper
    {
        public static void RegistrarCliente(Cliente cliente)
        {
            var identidade = new ClaimsIdentity("autenticacaoPorCookies");

            var claimNome = new Claim(ClaimTypes.Name, cliente.Nome);
            var claimId = new Claim("ClienteId", cliente.Id);

            identidade.AddClaim(claimNome);
            identidade.AddClaim(claimId);

            var contexto = HttpContext.Current.Request.GetOwinContext();
            var autenticador = contexto.Authentication;
            autenticador.SignIn(identidade);
            
            //HttpContext.Current.Session["cliente"] = cliente;
        }

        public static void LogOff()
        {
            var contexto = HttpContext.Current.Request.GetOwinContext();
            var autenticador = contexto.Authentication;
            autenticador.SignOut();
        }

        public static Cliente ObterClienteLogado()
        {
            var contexto = HttpContext.Current.Request.GetOwinContext();
            var autenticador = contexto.Authentication;
            var clienteCookie = autenticador.User;
            var cliente = new Cliente()
            {
                Id = clienteCookie.Claims.First(m => m.Type == "ClienteId").Value,
                Nome = clienteCookie.Identity.Name
            };

            return cliente;

            //return (Cliente)HttpContext.Current.Session["cliente"];
        }
    }
}