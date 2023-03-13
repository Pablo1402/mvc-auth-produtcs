using App.Interfaces.Repositories;
using App.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly MvcDbContext _context;

        public EnderecoRepository(MvcDbContext mvcDbContext)
        {
            _context = mvcDbContext;
        }

        public async Task DeleteAsync(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Endereco>> GetAllAsync()
        {
            var data = await _context.Enderecos.ToListAsync();
            return data;
        }

        public async Task<Endereco> GetByIdAsync(Guid id)
        {
            return await _context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
