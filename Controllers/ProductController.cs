using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProdcut(int id)
        {
            var product =  await _productRepository.Get(id);
            if (product == null)
                return NotFound();
            
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                DateCreated = System.DateTime.Now
            };

            await _productRepository.Add(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            Product product = new()
            {
                ProductId = id,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
            };

            await _productRepository.Update(product);
            return Ok();
        }
    }
}