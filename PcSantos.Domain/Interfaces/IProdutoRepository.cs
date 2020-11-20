using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public interface IProdutoRepository
    {
        List<Produto> ObterTodos();
        List<Produto> ObterPorCategoria(string categoria);
        Produto ObterPorId(string id);
    }
}
