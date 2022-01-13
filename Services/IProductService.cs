using Domain.Model;

namespace Services
{
    public interface IProductService
    {
        public Task<ServiceResponse<Product>> GetProductById(int id);
        public Task<ServiceResponse<List<Product>>> GetEntireStock();
        public Task<ServiceResponse<List<Product>>> AddNewProduct(Product newProduct);
        public Task<ServiceResponse<List<Product>>> UpdateProduct(Product updatedProduct);
        public Task<ServiceResponse<List<Product>>> RemoveProduct(int id);
    }
}