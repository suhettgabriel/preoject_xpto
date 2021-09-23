using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPTO_API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodBarra { get; set; }
        public byte[] imagem { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
