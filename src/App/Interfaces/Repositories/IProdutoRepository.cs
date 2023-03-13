using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveAsync(Produto produto);
        Task<List<Produto>> GetAllAsync();
        Task<List<Produto>> GetAsync(Expression<Func<Produto, bool>> expression);
        Task<Produto> GetByIdAsync(Guid id);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);

    }
}
