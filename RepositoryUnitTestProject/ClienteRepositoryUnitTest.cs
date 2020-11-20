using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcSantos.Domain;
using PcSantos.Repository;

namespace RepositoryUnitTestProject
{
    [TestClass]
    public class ClienteRepositoryUnitTest
    {
        [TestMethod]
        public void ClienteNovoTeste()
        {
            var clienteRep = new ClienteRepository();
            var cliente = new Cliente()
            { 
                Id = "abc4500",
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
            

            clienteRep.Incluir(cliente);

            var clienteGravado = clienteRep.ObterPorEmailSenha("lucas@teste.com.br", "teste1234");
            
            if (clienteGravado != null)
            {
                Console.WriteLine(clienteGravado.Id);
                Console.WriteLine(clienteGravado.Nome);
                Console.WriteLine(clienteGravado.Email);
                Console.WriteLine(clienteGravado.Senha);
                Console.WriteLine(clienteGravado.CPF);
                Console.WriteLine(clienteGravado.DataNasc);
                Console.WriteLine(clienteGravado.Sexo);
                Console.WriteLine(clienteGravado.Telefone);
                Console.WriteLine(clienteGravado.CEP);
                Console.WriteLine(clienteGravado.Endereco);
                Console.WriteLine(clienteGravado.Numero);
                Console.WriteLine(clienteGravado.Bairro);
                Console.WriteLine(clienteGravado.Cidade);
                Console.WriteLine(clienteGravado.Estado);
            }            

            Assert.IsNotNull(clienteGravado, "Não foi possível cadastrar o cliente");
        }

        [TestMethod]
        public void ClienteAlterarTeste()
        {            
            var clienteRep = new ClienteRepository();
            var cliente = new Cliente()
            {
                Id = "abc1234",
                Nome = "Lucas Teste",
                Email = "lucas@teste.com.br",
                Senha = "teste1234",
                CPF = "123.456.789-00",
                DataNasc = Convert.ToDateTime("03/11/2020"),
                Sexo = "F",
                Telefone = "(11) 0000-1111",
                CEP = "00000-111",
                Endereco = "Avenida etc",
                Numero = "1234",
                Bairro = "Vila Exemplo",
                Cidade = "Balneario Exemplo",
                Estado = "Exemplo Teste"
            };
            

            clienteRep.Alterar(cliente);

            var clienteAlterado = clienteRep.ObterPorEmailSenha("lucas@teste.com.br", "teste1234");

            if (clienteAlterado != null)
            {
                Console.WriteLine(clienteAlterado.Id);
                Console.WriteLine(clienteAlterado.Nome);
                Console.WriteLine(clienteAlterado.Email);
                Console.WriteLine(clienteAlterado.Senha);
                Console.WriteLine(clienteAlterado.CPF);
                Console.WriteLine(clienteAlterado.DataNasc);
                Console.WriteLine(clienteAlterado.Sexo);
                Console.WriteLine(clienteAlterado.Telefone);
                Console.WriteLine(clienteAlterado.CEP);
                Console.WriteLine(clienteAlterado.Endereco);
                Console.WriteLine(clienteAlterado.Numero);
                Console.WriteLine(clienteAlterado.Bairro);
                Console.WriteLine(clienteAlterado.Cidade);
                Console.WriteLine(clienteAlterado.Estado);
            }

            Assert.IsNotNull(clienteAlterado, "Não foi possível alterar o cliente");
        }

        [TestMethod]
        public void ClienteObterPorEmailSenhaTeste()
        {
            var clienteRep = new ClienteRepository();
            var cliente = new Cliente(); 

            cliente = clienteRep.ObterPorEmailSenha("lucas@teste.com.br", "teste1234");

            if (cliente != null)
            {
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
            }

            Assert.IsNotNull(cliente, "Não foi possível localizar a conta");
        }

        [TestMethod]
        public void ClienteObterPorIdTeste()
        {
            var clienteRep = new ClienteRepository();
            var cliente = new Cliente();

            cliente = clienteRep.ObterPorId("abc4500");

            if (cliente != null)
            {
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
            }

            Assert.IsNotNull(cliente, "Não foi possível localizar a conta");
        }
    }
}
