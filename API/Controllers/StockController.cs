using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IProductService _productService;
        public StockController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("stock")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetEntireStock()
        {
            return Ok(await _productService.GetEntireStock());
        }
        
        [HttpGet("stock/{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetEntireStock(int id)
        {
            var result = await _productService.GetProductById(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> DeleteById(int id)
        {
            var result = await _productService.RemoveProduct(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost("add-product")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> AddNewProduct(Product newProduct)
        {
            return await _productService.AddNewProduct(newProduct);
        }

        [HttpPut("update-product")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> UpdateProduct(Product updatedProduct)
        {
            var result = await _productService.UpdateProduct(updatedProduct);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }
    }
}