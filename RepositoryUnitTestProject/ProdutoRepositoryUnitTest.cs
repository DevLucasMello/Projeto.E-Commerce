using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcSantos.Domain;
using PcSantos.Repository;

namespace RepositoryUnitTestProject
{
    [TestClass]
    public class ProdutoRepositoryUnitTest
    {     
        [TestMethod]
        public void ProdutoObterTodosTeste()
        {
            var produtoRep = new ProdutoRepository();            

            var produtoList = produtoRep.ObterTodos();
            
            if (produtoList != null)
            {
                foreach (var p in produtoList)
                {
                    Console.WriteLine(p.Id);
                    Console.WriteLine(p.Categoria);
                    Console.WriteLine(p.Descricao);
                    Console.WriteLine(p.Valor);
                    Console.WriteLine(p.FichaTecnica);
                }
            }

            Assert.IsNotNull(produtoList, "Não foi possível localizar a conta");

            
            //Produto ObterPorId(string id);
        }

        [TestMethod]
        public void ProdutoObterPorCategoriaTeste()
        {
            var produtoRep = new ProdutoRepository();

            var produtoList = produtoRep.ObterPorCategoria("Processador");

            if (produtoList != null)
            {
                foreach (var p in produtoList)
                {
                    Console.WriteLine(p.Id);
                    Console.WriteLine(p.Categoria);
                    Console.WriteLine(p.Descricao);
                    Console.WriteLine(p.Valor);
                    Console.WriteLine(p.FichaTecnica);
                }
            }

            Assert.IsNotNull(produtoList, "Não foi possível localizar a conta");   
        }

        [TestMethod]
        public void ProdutoObterPorIdTeste()
        {
            var produtoRep = new ProdutoRepository();

            var produto = produtoRep.ObterPorId("abc2244");

            if (produto != null)
            {
                Console.WriteLine(produto.Id);
                Console.WriteLine(produto.Categoria);
                Console.WriteLine(produto.Descricao);
                Console.WriteLine(produto.Valor);
                Console.WriteLine(produto.FichaTecnica);
            }

            Assert.IsNotNull(produto, "Não foi possível localizar a conta");            
        }
    }
}
