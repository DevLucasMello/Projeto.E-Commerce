using PcSantos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.ApplicationServices
{
    public class ProdutoAppServices : IProdutoAppServices
    {
        private IProdutoRepository produtoRepository;

        public ProdutoAppServices(IProdutoRepository produtoRepositoryInstance)
        {
            this.produtoRepository = produtoRepositoryInstance;
        }
        
        public List<Produto> ObterPorCategoria(string categoria)
        {
            return produtoRepository.ObterPorCategoria(categoria);
        }

        public Produto ObterPorId(string id)
        {
            return produtoRepository.ObterPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            return produtoRepository.ObterTodos();
        }
    }
}
