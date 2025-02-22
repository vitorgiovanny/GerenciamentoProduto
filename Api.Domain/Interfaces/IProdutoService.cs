using Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProdutosAsync();
        Task<Product> GetProdutoByIdAsync(int id);
        Task AddProdutoAsync(Product produto);
        Task UpdateProdutoAsync(Product produto);
        Task DeleteProdutoAsync(int id);
    }
}
