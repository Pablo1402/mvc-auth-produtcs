using App.Models;

namespace App.Interfaces.Repositories
{
    public interface IFornecedorRepositoy
    {
        Task SaveAsync(Fornecedor fornecedor);
        Task<List<Fornecedor>> GetAllAsync();
        Task<Fornecedor> GetByIdAsync(Guid id);
        Task UpdateAsync(Fornecedor fornecedor);
        Task DeleteAsync(Fornecedor fornecedor);
    }
}
