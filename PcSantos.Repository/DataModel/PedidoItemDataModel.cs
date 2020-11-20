using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Repository
{
    public class PedidoItemDataModel
    {
        public string Id { get; set; }
        public string PedidoId { get; set; }
        public int NumeroPedido { get; set; }
        public string ProdutoId { get; set; }
        public string ProdutoCategoria { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoValor { get; set; }
        public string ProdutoFichaTecnica { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }
}
