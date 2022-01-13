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
            return Ok(await _productService.GetProductById(id));
        }
        
    }
}