using App.Interfaces.Repositories;
using App.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MvcDbContext _context;

        public ProdutoRepository(MvcDbContext mvcDbContext)
        {
            _context = mvcDbContext;
        }

        public async Task DeleteAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAsync(Expression<Func<Produto, bool>> expression)
        {
            var produtos = await _context.Produtos.Where(expression).Include(x => x.Fornecedor).AsNoTracking().ToListAsync();
            return produtos;
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            return produtos;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
