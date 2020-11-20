using PcSantos.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcSantos.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoAppServices produtoApp;

        public ProdutoController(IProdutoAppServices clienteAppInstance)
        {
            this.produtoApp = clienteAppInstance;
        }

        [AllowAnonymous]        
        public ActionResult Produto(string id)
        {
            var produto = produtoApp.ObterPorId(id);
            return View(produto);
        }
    }
}