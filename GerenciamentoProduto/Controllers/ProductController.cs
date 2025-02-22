using Api.Application.Dto;
using Api.Domain.Entity;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _services;

        public ProductController(IProductService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get() =>
           Ok(await _services.GetAllProdutosAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var produto = await _services.GetProdutoByIdAsync(id);
            return produto != null ? Ok(produto) : NotFound();
        }

        /// <summary>
        /// Para criar um novo produto deve colocar nome, preço e quantidade em estoque
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            await _services.AddProdutoAsync(new Product() { Name = product.Name, Price = product.Price, StockQuantity = product.StockQuantity});
            return CreatedAtAction(nameof(Get), new { name = product.Name}, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product produto)
        {
            if (id != produto.ProductID) return BadRequest();
            await _services.UpdateProdutoAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteProdutoAsync(id);
            return NoContent();
        }
    }
}
