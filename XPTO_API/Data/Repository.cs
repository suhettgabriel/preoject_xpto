using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTO_API.Models;

namespace XPTO_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity); 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //PRODUTOS
        public async Task<Produto[]> GetAllProdutosAsync(bool includeFornecedor = false)
        {
            IQueryable<Produto> query = _context.Produtos;
            if (includeFornecedor)
            {
                query = query
                    .Include(a => a.Fornecedor);
            }
            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Produto[]> GetProdutosAsyncByFornecedorId(int FornecedorId, bool includeFornecedor)
        {
            IQueryable<Produto> query = _context.Produtos;
            if (includeFornecedor)
            {
                query = query
                    .Include(a => a.Fornecedor);
            }
            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Where(produto => produto.FornecedorId == FornecedorId);
            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutosAsyncById(int ProdutoId, bool includeFornecedor)
        {
            IQueryable<Produto> query = _context.Produtos;
            if (includeFornecedor)
            {
                query = query
                    .Include(a => a.Fornecedor);
            }
            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Where(produto => produto.Id == ProdutoId);

            return await query.FirstOrDefaultAsync();
        }


        //FORNECEDOR
        public async Task<Fornecedor[]> GetAllFornecedoresAsync(bool includeProduto = false)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;
            if (includeProduto)
            {
                query = query
                    .Include(a => a.Produtos);
            }
            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
            return await query.ToArrayAsync();
        }

        public async Task<Fornecedor> GetFornecedorAsyncById(int FornecedorId, bool includeProduto)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;
            if (includeProduto)
            {
                query = query.Include(a => a.Produtos);
            }
            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Where(produto => produto.Id == FornecedorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
