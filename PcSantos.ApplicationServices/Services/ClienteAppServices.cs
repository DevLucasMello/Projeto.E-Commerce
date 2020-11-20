using PcSantos.Domain;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.ApplicationServices
{
    public class ClienteAppServices : IClienteAppServices
    {
        private IClienteRepository clienteRepository;

        public ClienteAppServices(IClienteRepository clienteRepositoryInstance)
        {
            this.clienteRepository = clienteRepositoryInstance;
        }
        
        public void Alterar(Cliente cliente)
        {
            clienteRepository.Alterar(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            clienteRepository.Incluir(cliente);
        }

        public Cliente ObterPorEmailSenha(string email, string senha)
        {
            return clienteRepository.ObterPorEmailSenha(email, senha);
        }

        public Cliente ObterPorId(string id)
        {
            return clienteRepository.ObterPorId(id);
        }

        public string CriarHash(string texto)

        {
            throw new NotImplementedException();
            /*var md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();*/

        }
    }
}
