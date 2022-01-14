using Domain.DTO;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Persistence;
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
        public async Task<ActionResult<ServiceResponse<List<GetProductDTO>>>> GetEntireStock()
        {
            return Ok(await _productService.GetEntireStock());
        }
        
        [HttpGet("stock/{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDTO>>> GetEntireStock(int id)
        {
            var result = await _productService.GetProductById(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDTO>>>> DeleteById(int id)
        {
            var result = await _productService.RemoveProduct(id);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost("add-product")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDTO>>>> AddNewProduct(AddProductDTO newProduct)
        {
            return await _productService.AddNewProduct(newProduct);
        }

        [HttpPut("update-product")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDTO>>>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            var result = await _productService.UpdateProduct(updatedProduct);

            if(result.Success)
                return Ok(result);

            return NotFound(result);
        }
    }
}