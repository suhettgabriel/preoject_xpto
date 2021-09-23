using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTO_API.Models;

namespace XPTO_API.Data
{
     public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Produto[]> GetAllProdutosAsync(bool includeFornecedor);

        Task<Produto[]> GetProdutosAsyncByFornecedorId(int FornecedorId, bool includeFornecedor);

        Task<Produto> GetProdutosAsyncById(int ProdutoId, bool includeFornecedor);



        Task<Fornecedor[]> GetAllFornecedoresAsync(bool includeProduto);
        Task<Fornecedor> GetFornecedorAsyncById(int FornecedorId, bool includeProduto);
    }
}
