using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcSantos.Domain;

namespace Domain.UnitTestProject
{
    [TestClass]
    public class PedidoUnitTest
    {
        [TestMethod]
        public void PedidoTeste()
        {
            var pedido = new Pedido();
            pedido.Id = Guid.NewGuid().ToString();
            pedido.Numero = 1;

            pedido.Cliente = new Cliente();
            pedido.Cliente.Id = Guid.NewGuid().ToString();
            pedido.Cliente.Nome = "Lucas Teste";
            pedido.Cliente.Email = "lucas@teste.com.br";
            pedido.Cliente.Senha = "teste1234";
            pedido.Cliente.CPF = "123.456.789-00";
            pedido.Cliente.DataNasc = Convert.ToDateTime("03/11/2020");
            pedido.Cliente.Sexo = "M";
            pedido.Cliente.Telefone = "(11) 1234-5678";
            pedido.Cliente.CEP = "01234-567";
            pedido.Cliente.Endereco = "Avenida etc";
            pedido.Cliente.Numero = "1234";
            pedido.Cliente.Bairro = "Vila Exemplo";
            pedido.Cliente.Cidade = "Balneario Exemplo";
            pedido.Cliente.Estado = "Exemplo Teste";  

            pedido.Status = (PedidoStatus)1;

            pedido.ListaProdutos = new List<PedidoItem>();
            pedido.ListaProdutos.Add(new PedidoItem()
            {
                Id = Guid.NewGuid().ToString(),
                Produto = new Produto()
                {
                    Id = Guid.NewGuid().ToString(),
                    Categoria = "Processador",
                    Descricao = "Ryzen 7",
                    Valor = 100,
                    FichaTecnica = "8 núcleos\n 4 theards"
                },
                Quantidade = 1,
                Total = 100
            });

            pedido.ValorTotal = 100;

            Console.WriteLine(pedido.Id);
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
