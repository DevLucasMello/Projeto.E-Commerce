using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.ApplicationServices
{
    public class PedidoAppServices : IPedidoAppServices
    {
        private IPedidoRepository pedidoRepository;

        public PedidoAppServices(IPedidoRepository pedidoRepositoryInstance)
        {
            this.pedidoRepository = pedidoRepositoryInstance;
        }

        public void IncluirPedido(Pedido pedido)
        {
            pedidoRepository.IncluirPedido(pedido);
        }

        public void IncluirPedidoItem(Pedido pedido)
        {
            pedidoRepository.IncluirPedidoItem(pedido);
        }

        public List<Pedido> ObterPedidoPorClienteId(string clienteId)
        {
            return pedidoRepository.ObterPedidoPorClienteId(clienteId);            
        }

        public Pedido ObterPedidoPorId(string id)
        {
            return pedidoRepository.ObterPedidoPorId(id);
        }

        public Pedido ObterPedidoPorNumero(int numero)
        {
            return pedidoRepository.ObterPedidoPorNumero(numero);
        }
    }
}
