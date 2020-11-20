using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public class Pedido
    {
        public Pedido()
        {
            Status = PedidoStatus.AguardandoPagamento;
        }        
        public string Id { get; set; }
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
        public PedidoStatus Status { get; set; }
        public List<PedidoItem> ListaProdutos { get; set; }

        public string StatusDescricao
        {
            get
            {
                switch (Status)
                {
                    case PedidoStatus.AguardandoPagamento:
                        return "Aguardando Pagamento";
                    case PedidoStatus.PagamentoAprovado:
                        return "Pagamento Aprovado";
                    case PedidoStatus.EmitindoNotaFiscal:
                        return "Emitindo Nota Fiscal";
                    case PedidoStatus.EmSeparacao:
                        return "Em Separacao";
                    case PedidoStatus.EmTransporte:
                        return "Em Transporte";
                    case PedidoStatus.Entregue:
                        return "Entregue";
                    default:
                        return string.Empty;
                }
            }
        }
        public decimal ValorTotal { get; set; }        
    }
}
