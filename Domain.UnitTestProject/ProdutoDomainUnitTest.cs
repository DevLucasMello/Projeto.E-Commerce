using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcSantos.Domain;

namespace Domain.UnitTestProject
{
    [TestClass]
    public class ProdutoDomainUnitTest
    {
        [TestMethod]
        public void ProdutoTeste()
        {
            var produto = new Produto();
            produto.Id = Guid.NewGuid().ToString();
            produto.Categoria = "Processador";
            produto.Descricao = "Ryzen 7";
            produto.Valor = 100;
            produto.FichaTecnica = "8 núcleos\n" +
                                    "4 theards";

            Console.WriteLine(produto.Id);
            Console.WriteLine(produto.Categoria);
            Console.WriteLine(produto.Descricao);
            Console.WriteLine(produto.Valor);

            Assert.IsTrue(produto.Categoria != null, "A categoria deve ser preenchida");
        }
    }
}
