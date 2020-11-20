using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public interface IPedidoRepository
    {
        void IncluirPedido(Pedido pedido);
        void IncluirPedidoItem(Pedido pedido);
        List<Pedido> ObterPedidoPorClienteId(string clienteId);        
        Pedido ObterPedidoPorNumero(int Numero);
        Pedido ObterPedidoPorId(string id);
    }
}
