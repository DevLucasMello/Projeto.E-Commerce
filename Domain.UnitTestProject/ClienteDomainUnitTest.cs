using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcSantos.Domain;

namespace Domain.UnitTestProject
{
    [TestClass]
    public class ClienteDomainUnitTest
    {
        [TestMethod]
        public void ClienteTeste()
        {
            var cliente = new Cliente();
            cliente.Id = Guid.NewGuid().ToString();
            cliente.Nome = "Lucas Teste";
            cliente.Email = "lucas@teste.com.br";
            cliente.Senha = "teste1234";
            cliente.CPF = "123.456.789-00";
            cliente.DataNasc = Convert.ToDateTime("03/11/2020");
            cliente.Sexo = "M";
            cliente.Telefone = "(11) 1234-5678";
            cliente.CEP = "01234-567";
            cliente.Endereco = "Avenida etc";
            cliente.Numero = "1234";
            cliente.Bairro = "Vila Exemplo";
            cliente.Cidade = "Balneario Exemplo";
            cliente.Estado = "Exemplo Teste";

            Console.WriteLine(cliente.Id);
            Console.WriteLine(cliente.Nome);
            Console.WriteLine(cliente.Email);
            Console.WriteLine(cliente.Senha);
            Console.WriteLine(cliente.CPF);
            Console.WriteLine(cliente.DataNasc);
            Console.WriteLine(cliente.Sexo);
            Console.WriteLine(cliente.Telefone);
            Console.WriteLine(cliente.CEP);
            Console.WriteLine(cliente.Endereco);
            Console.WriteLine(cliente.Numero);
            Console.WriteLine(cliente.Bairro);
            Console.WriteLine(cliente.Cidade);
            Console.WriteLine(cliente.Estado);

            Assert.IsTrue(cliente.Nome != null, "O nome não foi preenchido");
        }
    }
}
