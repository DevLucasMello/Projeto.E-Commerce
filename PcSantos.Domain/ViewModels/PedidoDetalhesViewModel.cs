using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public class PedidoDetalhesViewModel
    {
        public int NumeroPedido { get; set; }        
        public List<PedidoItem> Produtos { get; set; }
        public decimal ValorTotal { get; set; }
        public PedidoStatus StatusPedido { get; set; }
    }
}
