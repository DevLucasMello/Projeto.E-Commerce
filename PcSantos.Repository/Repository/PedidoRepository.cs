using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public void IncluirPedido(Pedido pedido)
        {
            DbHelper.Execute("PedidoIncluir", new
            {                
                Id = pedido.Id,
                Numero = pedido.Numero,
                ClienteId = pedido.Cliente.Id,
                ClienteNome = pedido.Cliente.Nome,
                ClienteEmail = pedido.Cliente.Email,
                ClienteSenha = pedido.Cliente.Senha,
                ClienteCPF = pedido.Cliente.CPF,
                ClienteDataNasc = pedido.Cliente.DataNasc,
                ClienteSexo = pedido.Cliente.Sexo,
                ClienteTelefone = pedido.Cliente.Telefone,
                ClienteCEP = pedido.Cliente.CEP,
                ClienteEndereco = pedido.Cliente.Endereco,
                ClienteNumero = pedido.Cliente.Numero,
                ClienteBairro = pedido.Cliente.Bairro,
                ClienteCidade = pedido.Cliente.Cidade,
                ClienteEstado = pedido.Cliente.Estado,
                PedidoStatus = (int)pedido.Status,
                ValorTotal = pedido.ValorTotal 
            });
        }

        public void IncluirPedidoItem(Pedido pedido)
        {
            foreach (var p in pedido.ListaProdutos)
            {
                DbHelper.Execute("PedidoItemIncluir", new
                {
                    Id = p.Id,
                    PedidoId = pedido.Id,
                    NumeroPedido = pedido.Numero,
                    ProdutoId = p.Produto.Id,
                    ProdutoCategoria = p.Produto.Categoria,
                    ProdutoDescricao = p.Produto.Descricao,
                    ProdutoValor = p.Produto.Valor,
                    ProdutoFichaTecnica = p.Produto.FichaTecnica,
                    Quantidade = p.Quantidade,
                    Total = p.Total
                });
            }
        }

        public List<Pedido> ObterPedidoPorClienteId(string clienteId)
        {
            var pedidosClienteId = new List<Pedido>();
            var pedidoListDataModel = DbHelper.Query<PedidoDataModel>("PedidoObterPorClienteId", new { ClienteId = clienteId });
            foreach (var p in pedidoListDataModel)
            {
                pedidosClienteId.Add(ObterPedidoPorNumero(p.Numero));
            }
            return pedidosClienteId;
        }

        public Pedido ObterPedidoPorId(string id)
        {
            var pedidoDataModel = DbHelper.QueryFirstOrDefault<PedidoDataModel>("PedidoObterPorId", new { Id = id });
            var pedido = pedidoDataModel.ToPedido();            
            
            return pedido;
        }

        public Pedido ObterPedidoPorNumero(int numero)
        {
            var pedidoDataModel = DbHelper.QueryFirstOrDefault<PedidoDataModel>("PedidoObterPorNumero", new { Numero = numero });
            var pedido = pedidoDataModel.ToPedido();

            var pedidoListDataModel = DbHelper.Query<PedidoItemDataModel>("PedidoItemObterPorNumeroPedido", new { NumeroPedido = numero });

            pedido.ListaProdutos = new List<PedidoItem>();
            foreach (var p in pedidoListDataModel)
            {
                pedido.ListaProdutos.Add(new PedidoItem()
                {
                    Id = p.Id,
                    NumeroPedido = p.NumeroPedido,
                    Produto = new Produto()
                    {
                        Id = p.ProdutoId,
                        Categoria = p.ProdutoCategoria,
                        Descricao = p.ProdutoDescricao,
                        Valor = p.ProdutoValor,
                        FichaTecnica = p.ProdutoFichaTecnica,
                    },
                    Quantidade = p.Quantidade,
                    Total = p.Total
                });
            }
            return pedido;
        }
    }
}
