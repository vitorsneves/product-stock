using Domain.DTO;
using Domain.Model;

namespace Services
{
    public interface IProductService
    {
        public Task<ServiceResponse<GetProductDTO>> GetProductById(int id);
        public Task<ServiceResponse<List<GetProductDTO>>> GetEntireStock();
        public Task<ServiceResponse<List<GetProductDTO>>> AddNewProduct(AddProductDTO newProduct);
        public Task<ServiceResponse<List<GetProductDTO>>> UpdateProduct(UpdateProductDTO updatedProduct);
        public Task<ServiceResponse<List<GetProductDTO>>> RemoveProduct(int id);
    }
}