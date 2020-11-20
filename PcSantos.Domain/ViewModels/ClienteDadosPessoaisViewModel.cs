using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public class ClienteDadosPessoaisViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
    }
}
