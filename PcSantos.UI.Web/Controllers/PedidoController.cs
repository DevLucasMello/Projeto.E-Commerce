using PcSantos.ApplicationServices;
using PcSantos.Domain;
using PcSantos.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcSantos.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoAppServices pedidoApp;
        private IProdutoAppServices produtoApp;
        private IClienteAppServices clienteApp;

        public PedidoController(IPedidoAppServices pedidoAppInstance, IProdutoAppServices produtoAppInstance, IClienteAppServices clienteAppInstance)
        {
            this.pedidoApp = pedidoAppInstance;
            this.produtoApp = produtoAppInstance;
            this.clienteApp = clienteAppInstance;
        }
        
        [Authorize]
        public ActionResult Compra(string id)
        {              
            var produto = produtoApp.ObterPorId(id);
            var pedidoCompraViewModel = new PedidoCompraViewModel()
            {
                Id = produto.Id,
                Categoria = produto.Categoria,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                FichaTecnica = produto.FichaTecnica,
                ValorTotal = produto.Valor
            };
            return View(pedidoCompraViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Compra(PedidoCompraViewModel pedidoViewModel)
        {
            var clienteId = AppHelper.ObterClienteLogado();
            var cliente = clienteApp.ObterPorId(clienteId.Id);

            var pedido = new Pedido()
            {
                Id = Guid.NewGuid().ToString(),
                Cliente = new Cliente()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Senha = cliente.Senha,
                    CPF = cliente.CPF,
                    DataNasc = cliente.DataNasc,
                    Sexo = cliente.Sexo,
                    Telefone = cliente.Telefone,
                    CEP = cliente.CEP,
                    Endereco = cliente.Endereco,
                    Numero = cliente.Numero,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    Estado = cliente.Estado
                },
                Status = (PedidoStatus)1,
                ListaProdutos = new List<PedidoItem>()
            };

            var consultaProduto = produtoApp.ObterPorId(pedidoViewModel.Id);
                
            var produto = new Produto()
            {
                Id = consultaProduto.Id,
                Categoria = consultaProduto.Categoria,
                Descricao = consultaProduto.Descricao,
                Valor = consultaProduto.Valor,
                FichaTecnica = consultaProduto.FichaTecnica
            };


            var lista = new PedidoItem()
            {
                Id = Guid.NewGuid().ToString(),
                PedidoId = pedido.Id,
                NumeroPedido = pedido.Numero,                    
                Produto = produto,
                Quantidade = 2                
            };
            lista.Total = produto.Valor * lista.Quantidade;

            var listaPed = new List<PedidoItem>();

            listaPed.Add(lista);            
            
            foreach (var p in listaPed)
            {
                pedido.ValorTotal += p.Total;
            }

            pedido.ListaProdutos.Add(lista);            

            pedidoApp.IncluirPedido(pedido); 
            
            
            
            var consultaPedido = pedidoApp.ObterPedidoPorId(pedido.Id);

            var pedido2 = new Pedido()
            {
                Numero = consultaPedido.Numero,                
                ListaProdutos = new List<PedidoItem>()
            };

            var produto2 = new Produto()
            {
                Id = consultaProduto.Id,
                Categoria = consultaProduto.Categoria,
                Descricao = consultaProduto.Descricao,
                Valor = consultaProduto.Valor,
                FichaTecnica = consultaProduto.FichaTecnica
            };


            var lista2 = new PedidoItem()
            {
                Id = Guid.NewGuid().ToString(),
                PedidoId = pedido.Id,
                NumeroPedido = consultaPedido.Numero,
                Produto = produto2,
                Quantidade = 2                
            };
            lista2.Total = produto2.Valor * lista2.Quantidade;

            pedido2.ListaProdutos.Add(lista2);            

            pedidoApp.IncluirPedidoItem(pedido2);

            return RedirectToAction("CompraFinalizada");
            
        }

        [Authorize]
        public ActionResult CompraFinalizada()
        {
            return View();
        }

        [Authorize]
        public ActionResult Pedidos(string id)
        {
            var cliente = clienteApp.ObterPorId(id);
            var pedidosCliente = pedidoApp.ObterPedidoPorClienteId(cliente.Id);
            
                      
            var pedidos = new List<PedidoDetalhesViewModel>();  
            
            foreach(var p in pedidosCliente)
            {
                var numero = p.Numero;
                var ped = pedidoApp.ObterPedidoPorNumero(numero);

                var pedid = new Pedido()
                {
                    Numero = ped.Numero,
                    ListaProdutos = new List<PedidoItem>(),
                    ValorTotal = ped.ValorTotal,
                    Status = ped.Status
                };

                foreach (var f in ped.ListaProdutos)
                {
                    pedid.ListaProdutos.Add(new PedidoItem()
                    {
                        Produto = new Produto()
                        {
                            Categoria = f.Produto.Categoria,
                            Descricao = f.Produto.Descricao,
                            Valor = f.Produto.Valor,
                        },
                        Quantidade = f.Quantidade,
                        Total = f.Total
                    });
                }
                pedidos.Add(new PedidoDetalhesViewModel
                {
                    NumeroPedido = pedid.Numero,
                    Produtos = pedid.ListaProdutos,
                    ValorTotal = pedid.ValorTotal,
                    StatusPedido = pedid.Status
                });
            }
            return View(pedidos);
        }
    }
}