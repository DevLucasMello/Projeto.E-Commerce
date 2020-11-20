using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcSantos.Domain;
using PcSantos.Repository;

namespace RepositoryUnitTestProject
{
    [TestClass]
    public class PedidoRepositoryUnitTest
    {
        [TestMethod]
        public void IncluirPedidoTeste()
        {
            var pedidoRep = new PedidoRepository();
            var cliente = new Cliente()
            {
                Id = "abb1100",
                Nome = "Lucas Teste",
                Email = "lucas@teste.com.br",
                Senha = "teste1234",
                CPF = "123.456.789-00",
                DataNasc = Convert.ToDateTime("03/11/2020"),
                Sexo = "M",
                Telefone = "(11) 1234-5678",
                CEP = "01234-567",
                Endereco = "Avenida etc",
                Numero = "1234",
                Bairro = "Vila Exemplo",
                Cidade = "Balneario Exemplo",
                Estado = "Exemplo Teste"
            };

            var pedido = new Pedido()
            {                
                Numero = 1,
                Cliente = cliente,
                Status = (PedidoStatus)1,
                ValorTotal = 5100
            }; 

            pedidoRep.IncluirPedido(pedido);

            //var pedidoGravado = pedidoRep.ObterPedidoPorClienteId(cliente.Id);

            Assert.IsNotNull(pedido.ListaProdutos != null, "Não foi possível gerar o pedido");
        }

        [TestMethod]
        public void IncluirPedidoItemTeste()
        {
            var pedidoRep = new PedidoRepository();  
            var pedido = new Pedido()
            {
                Numero = 1,                
                Status = (PedidoStatus)1,
                ValorTotal = 5100
            };

            pedido.ListaProdutos = new List<PedidoItem>();

            var produto = new Produto()
            {
                Id = "ddc4422",
                Categoria = "Processador",
                Descricao = "Ryzen7 2700",
                Valor = 1200,
                FichaTecnica = "8 núcleos e 16 theards"
            };

            var lista = new PedidoItem()
            {
                Id = Guid.NewGuid().ToString(),
                NumeroPedido = 1,
                Produto = produto,
                Quantidade = 2,
                Total = 2400
            };
            pedido.ListaProdutos.Add(lista);

            produto = new Produto()
            {
                Id = "ggt7744",
                Categoria = "Processador",
                Descricao = "Ryzen5 2400",
                Valor = 900,
                FichaTecnica = "4 núcleos e 8 theards"
            };

            lista = new PedidoItem()
            {
                Id = Guid.NewGuid().ToString(),
                NumeroPedido = 1,
                Produto = produto,
                Quantidade = 3,
                Total = 2700
            };
            pedido.ListaProdutos.Add(lista);

            pedidoRep.IncluirPedidoItem(pedido);

            //var pedidoGravado = pedidoRep.ObterPedidoPorClienteId(cliente.Id);

            Assert.IsNotNull(pedido.ListaProdutos != null, "Não foi possível gerar o pedido");
        }

        [TestMethod]
        public void ObterPedidoPorClienteIdTeste()
        {
            var pedidoRep = new PedidoRepository();
                        
            var pedido = pedidoRep.ObterPedidoPorClienteId("abb1100");

            var lista = new List<PedidoItem>();
            foreach (var p in pedido)
            {                
                Console.WriteLine(p.Numero);
                Console.WriteLine(p.Cliente.Id);
                Console.WriteLine(p.Cliente.Nome);
                Console.WriteLine(p.Cliente.Email);
                Console.WriteLine(p.Cliente.Senha);
                Console.WriteLine(p.Cliente.CPF);
                Console.WriteLine(p.Cliente.DataNasc);
                Console.WriteLine(p.Cliente.Sexo);
                Console.WriteLine(p.Cliente.Telefone);
                Console.WriteLine(p.Cliente.CEP);
                Console.WriteLine(p.Cliente.Endereco);
                Console.WriteLine(p.Cliente.Numero);
                Console.WriteLine(p.Cliente.Bairro);
                Console.WriteLine(p.Cliente.Cidade);
                Console.WriteLine(p.Cliente.Estado);
                Console.WriteLine(p.Status);                
                lista = p.ListaProdutos;
                foreach (var pL in lista)
                {
                    Console.WriteLine(pL.Id);
                    Console.WriteLine(pL.NumeroPedido);
                    Console.WriteLine(pL.Produto.Id);
                    Console.WriteLine(pL.Produto.Categoria);
                    Console.WriteLine(pL.Produto.Descricao);
                    Console.WriteLine(pL.Produto.Valor);
                    Console.WriteLine(pL.Produto.FichaTecnica);
                    Console.WriteLine(pL.Quantidade);
                    Console.WriteLine(pL.Total);
                }
                Console.WriteLine(p.ValorTotal);
            }  

            Assert.IsTrue(pedido != null, "O Pedido não foi encontrado");
        }

        [TestMethod]
        public void ObterPedidoPorNumeroTeste()
        {
            var pedidoRep = new PedidoRepository();

            var pedido = new Pedido();
            pedido = pedidoRep.ObterPedidoPorNumero(1);
            
            Console.WriteLine(pedido.Numero);

            Console.WriteLine(pedido.Cliente.Id);
            Console.WriteLine(pedido.Cliente.Nome);
            Console.WriteLine(pedido.Cliente.Email);
            Console.WriteLine(pedido.Cliente.Senha);
            Console.WriteLine(pedido.Cliente.CPF);
            Console.WriteLine(pedido.Cliente.DataNasc);
            Console.WriteLine(pedido.Cliente.Sexo);
            Console.WriteLine(pedido.Cliente.Telefone);
            Console.WriteLine(pedido.Cliente.CEP);
            Console.WriteLine(pedido.Cliente.Endereco);
            Console.WriteLine(pedido.Cliente.Numero);
            Console.WriteLine(pedido.Cliente.Bairro);
            Console.WriteLine(pedido.Cliente.Cidade);
            Console.WriteLine(pedido.Cliente.Estado);

            Console.WriteLine(pedido.Status);

            foreach (var p in pedido.ListaProdutos)
            {
                Console.WriteLine(p.Id);
                Console.WriteLine(p.Produto.Id);
                Console.WriteLine(p.Produto.Categoria);
                Console.WriteLine(p.Produto.Descricao);
                Console.WriteLine(p.Produto.Valor);
                Console.WriteLine(p.Produto.FichaTecnica);
                Console.WriteLine(p.Quantidade);
                Console.WriteLine(p.Total);
            }
            Console.WriteLine(pedido.ValorTotal);

            Assert.IsTrue(pedido.Cliente != null, "O Pedido não foi efetuado");
        }
    }
}
