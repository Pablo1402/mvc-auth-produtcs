using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task SaveAsync(Endereco endereco);
        Task<List<Endereco>> GetAllAsync();
        Task<Endereco> GetByIdAsync(Guid id);
        Task UpdateAsync(Endereco endereco);
        Task DeleteAsync(Endereco endereco);
    }
}
