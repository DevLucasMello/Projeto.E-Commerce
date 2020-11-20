using PcSantos.ApplicationServices;
using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcSantos.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        IClienteAppServices clienteApp;

        public ClienteController(IClienteAppServices clienteAppInstance)
        {
            this.clienteApp = clienteAppInstance;
        }

        public ActionResult LogOff()
        {
            AppHelper.LogOff();

            return RedirectToAction("Inicio", "WebApp");
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            var clienteLoginViewModel = new ClienteLoginViewModel();
            return View(clienteLoginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(ClienteLoginViewModel clienteLoginViewModel)
        {
            //string senha = clienteApp.CriarHash(clienteLoginViewModel.Senha);
            Cliente cliente = clienteApp.ObterPorEmailSenha(clienteLoginViewModel.Email, clienteLoginViewModel.Senha);

            if (cliente == null)
            {
                clienteLoginViewModel.Mensagem = "Cliente não encontrado";
                return RedirectToAction("Login");
            }
            else
            {
                AppHelper.RegistrarCliente(cliente);
                return RedirectToAction("Inicio", "WebApp");
            }            
        }

        [AllowAnonymous]
        public ActionResult Registro()
        {
            var cliente = new ClienteRegistroViewModel();
            return View(cliente);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registro(ClienteRegistroViewModel clienteRegistro)
        {
            if (string.IsNullOrEmpty(clienteRegistro.Email))
            {
                ModelState.AddModelError("Email", "O email deve ser informado");
            }

            if (string.IsNullOrEmpty(clienteRegistro.Senha))
            {
                ModelState.AddModelError("Senha", "O email deve ser informado");
            }
            else
            {
                if (clienteRegistro.Senha != clienteRegistro.ConfirmarSenha)
                {
                    ModelState.AddModelError("ConfirmarSenha", "A confirmação deve ser igual a senha");
                }
            }            

            if(ModelState.IsValid)
            {
                var cliente = new Cliente();

                cliente.Id = Guid.NewGuid().ToString();
                cliente.Nome = clienteRegistro.Nome;
                cliente.Email = clienteRegistro.Email;
                cliente.Senha = clienteRegistro.Senha;
                cliente.CPF = clienteRegistro.CPF;
                cliente.DataNasc = clienteRegistro.DataNasc;
                cliente.Sexo = clienteRegistro.Sexo;
                cliente.Telefone = clienteRegistro.Telefone;
                cliente.CEP = clienteRegistro.CEP;
                cliente.Endereco = clienteRegistro.Endereco;
                cliente.Numero = clienteRegistro.Numero;
                cliente.Bairro = clienteRegistro.Bairro;
                cliente.Cidade = clienteRegistro.Cidade;
                cliente.Estado = clienteRegistro.Estado;                

                clienteApp.Incluir(cliente);

                AppHelper.RegistrarCliente(cliente);
                return RedirectToAction("Inicio", "WebApp");
            }  
            return View(clienteRegistro);
        }

        [Authorize]
        public ActionResult DashboardCliente()
        {
            var cliente = AppHelper.ObterClienteLogado();

            if (cliente == null)
            {
                return RedirectToAction("Login");
            }

            return View(cliente);
        }

        [Authorize]
        public ActionResult DadosPessoais(string id)
        {            
            var cliente = clienteApp.ObterPorId(id);

            var clienteDadosPessoais = new ClienteDadosPessoaisViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Senha = cliente.Senha,
                CPF = cliente.CPF,
                DataNasc = cliente.DataNasc,
                Sexo = cliente.Sexo,
                Telefone = cliente.Telefone
            };  

            return View(clienteDadosPessoais);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DadosPessoais(ClienteDadosPessoaisViewModel dadosPessoais)
        {
            try
            {

                var cliente = clienteApp.ObterPorId(dadosPessoais.Id);

                var clienteAlterar = new Cliente()
                {
                    Id = cliente.Id,
                    Nome = dadosPessoais.Nome,
                    Email = dadosPessoais.Email,
                    Senha = dadosPessoais.Senha,
                    CPF = dadosPessoais.CPF,
                    DataNasc = dadosPessoais.DataNasc,
                    Sexo = dadosPessoais.Sexo,
                    Telefone = dadosPessoais.Telefone,
                    CEP = cliente.CEP,
                    Endereco = cliente.Endereco,
                    Numero = cliente.Numero,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    Estado = cliente.Estado
                };

                clienteApp.Alterar(clienteAlterar);

                return RedirectToAction("DashboardCliente");
            }
            catch
            {
                return View(dadosPessoais);
            }
        }


        [Authorize]
        public ActionResult Endereco(string id)
        {
            var cliente = clienteApp.ObterPorId(id);

            var clienteEndereco = new ClienteEnderecoViewModel()
            {
                Id = cliente.Id,
                CEP = cliente.CEP,
                Endereco = cliente.Endereco,
                Numero = cliente.Numero,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                Estado = cliente.Estado                
            };

            return View(clienteEndereco);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Endereco(ClienteEnderecoViewModel clienteEndereco)
        {
            try
            {

                var cliente = clienteApp.ObterPorId(clienteEndereco.Id);

                var clienteAlterar = new Cliente()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Senha = cliente.Senha,
                    CPF = cliente.CPF,
                    DataNasc = cliente.DataNasc,
                    Sexo = cliente.Sexo,
                    Telefone = cliente.Telefone,
                    CEP = clienteEndereco.CEP,
                    Endereco = clienteEndereco.Endereco,
                    Numero = clienteEndereco.Numero,
                    Bairro = clienteEndereco.Bairro,
                    Cidade = clienteEndereco.Cidade,
                    Estado = clienteEndereco.Estado
                };

                clienteApp.Alterar(clienteAlterar);

                return RedirectToAction("DashboardCliente");
            }
            catch
            {
                return View(clienteEndereco);
            }
        }
    }
}