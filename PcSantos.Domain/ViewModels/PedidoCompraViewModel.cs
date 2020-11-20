using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcSantos.Domain;

namespace PcSantos.Domain.ViewModels
{
    public class PedidoCompraViewModel:Produto
    {
        public long NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoSeguranca { get; set; }
        public int NumeroPercelas { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
