using Api.Domain.Entity;
using Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _produtoRepository;

        public ProductService(IProductRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProdutosAsync() 
            => await _produtoRepository.GetAllAsync();

        public async Task<Product> GetProdutoByIdAsync(int id)
        {
            if (id == 0) throw new ArgumentException("Id is zero");

            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task AddProdutoAsync(Product produto)
        {
            if (!produto.ExistStock() || produto.IsZeroPrice()) throw new Exception("Stock or Price is zero");

            await _produtoRepository.AddAsync(produto);
        }

        public async Task UpdateProdutoAsync(Product produto)
        {
            if(!produto.ExistStock() || produto.ProductID == 0 || produto.IsZeroPrice()) throw new Exception("Stock, Id or Price is zero");

            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            if(id == 0) throw new ArgumentException("Id is zero");

            if(await GetProdutoByIdAsync(id) == null) throw new ArgumentException("Product isn't Exists");

            await _produtoRepository.DeleteAsync(id);
        }
    }
}
