using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public interface IClienteRepository
    {
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);        
        Cliente ObterPorEmailSenha(string email, string senha);
        Cliente ObterPorId(string id);
    }
}
