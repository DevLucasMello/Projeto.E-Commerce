using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public List<Produto> ObterPorCategoria(string categoria)
        {
            return DbHelper.Query<Produto>("ProdutoObterPorCategoria", new { Categoria = categoria});
        }

        public Produto ObterPorId(string id)
        {
            return DbHelper.QueryFirstOrDefault<Produto>("ProdutoObterPorId", new { Id = id });
        }

        public List<Produto> ObterTodos()
        {
            return DbHelper.Query<Produto>("ProdutoObterTodos", null);
        }
    }
}
