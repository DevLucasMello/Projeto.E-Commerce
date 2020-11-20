using PcSantos.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcSantos.UI.Web.Controllers
{
    public class WebAppController : Controller
    {
        private IProdutoAppServices produtoApp;

        public WebAppController(IProdutoAppServices clienteAppInstance)
        {
            this.produtoApp = clienteAppInstance;
        }

        [AllowAnonymous]
        public ActionResult Inicio()
        {
            var produtos = produtoApp.ObterTodos();
            return View(produtos);
        }
    }
}