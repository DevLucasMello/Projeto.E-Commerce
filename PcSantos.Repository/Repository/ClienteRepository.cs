using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public void Incluir(Cliente cliente)
        {
            DbHelper.Execute("ClienteIncluir", cliente);
        }

        public void Alterar(Cliente cliente)
        {
            DbHelper.Execute("ClienteAlterar", cliente);
        }        

        public Cliente ObterPorEmailSenha(string email, string senha)
        {
            return DbHelper.QueryFirstOrDefault<Cliente>("ClienteObterPorEmailSenha", new { Email = email, Senha = senha });
        }

        public Cliente ObterPorId(string id)
        {
            return DbHelper.QueryFirstOrDefault<Cliente>("ClienteObterPorId", new { Id = id });
        }
    }
}
