using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public enum PedidoStatus
    {
        AguardandoPagamento = 1,
        PagamentoAprovado = 2,
        EmitindoNotaFiscal = 3,
        EmSeparacao = 4,
        EmTransporte = 5,
        Entregue = 6
    }
}
