using Api.Domain.Entity;
using Api.Domain.Interfaces;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
            => _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Produtos.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) 
            => await _context.Produtos.FindAsync(id);

        public async Task AddAsync(Product produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await GetByIdAsync(id);
            if (produto is null) return;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
