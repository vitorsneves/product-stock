using Domain.Model;

namespace Services
{
    public interface IProductService
    {
        public Task<ServiceResponse<Product>> GetProductById(int id);
        public Task<ServiceResponse<List<Product>>> GetEntireStock();
        public Task<List<Product>> AddNewProduct(Product newProduct);
        public Task<List<Product>> UpdateProduct(Product updatedProduct);
        public Task<List<Product>> RemoveProduct(int id);
    }
}