using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcSantos.Domain
{
    public class Produto
    {
        public string Id { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string FichaTecnica { get; set; }        
    }
}
