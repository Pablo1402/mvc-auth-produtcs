using App.Interfaces.Repositories;
using App.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class FornecedorRepositoy : IFornecedorRepositoy
    {
        private readonly MvcDbContext _context;

        public FornecedorRepositoy(MvcDbContext mvcDbContext)
        {
            _context = mvcDbContext;
        }

        public async Task DeleteAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Fornecedor>> GetAllAsync()
        {
            var fornecedores = await _context.Fornecedores.ToListAsync();
            return fornecedores;
        }

        public async Task<Fornecedor> GetByIdAsync(Guid id)
        {
            return await _context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync(Fornecedor fornecedor)
        {
            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
        }
    }
}
