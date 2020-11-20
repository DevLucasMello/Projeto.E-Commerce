using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public class PedidoItem
    {
        public string Id { get; set; }
        public string PedidoId { get; set; }
        public int NumeroPedido { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }        
    }
}
