using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPTO_API.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }

    }
}
