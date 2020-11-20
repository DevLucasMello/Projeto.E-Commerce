using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Repository
{
    public class PedidoDataModel
    {        
        public string Id { get; set; }
        public int Numero { get; set; }
        public int PedidoStatus { get; set; }
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteSenha { get; set; }
        public string ClienteCPF { get; set; }
        public DateTime ClienteDataNasc { get; set; }
        public string ClienteSexo { get; set; }
        public string ClienteTelefone { get; set; }
        public string ClienteCEP { get; set; }
        public string ClienteEndereco { get; set; }
        public string ClienteNumero { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteCidade { get; set; }
        public string ClienteEstado { get; set; }        
        public decimal ValorTotal { get; set; }
        
        public Pedido ToPedido()
        {
            var p = new Pedido();
            p.Id = this.Id;
            p.Numero = this.Numero;
            p.Cliente = new Cliente();
            p.Cliente.Id = this.ClienteId;
            p.Cliente.Nome = this.ClienteNome;
            p.Cliente.Email = this.ClienteEmail;
            p.Cliente.Senha = this.ClienteSenha;
            p.Cliente.CPF = this.ClienteCPF;
            p.Cliente.DataNasc = this.ClienteDataNasc;
            p.Cliente.Sexo = this.ClienteSexo;
            p.Cliente.Telefone = this.ClienteTelefone;
            p.Cliente.CEP = this.ClienteCEP;
            p.Cliente.Endereco = this.ClienteEndereco;
            p.Cliente.Numero = this.ClienteNumero;
            p.Cliente.Bairro = this.ClienteBairro;
            p.Cliente.Cidade = this.ClienteCidade;
            p.Cliente.Estado = this.ClienteEstado;
            p.Status = (PedidoStatus)this.PedidoStatus;
            p.ValorTotal = this.ValorTotal;

            return p;
        }
    }
}
