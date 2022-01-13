using Domain.Model;
using Persistence;

namespace Services
{
    public class ProductService : IProductService
    {
        // private readonly ProductContext _context;
        // public ProductService(ProductContext context) 
        // {
        //     _context = context;
        // }

        private List<Product> stock = new List<Product>()
        {
            new Product() {Description = "brigadeiro"},
            new Product() {Description = "chocolate"},
            new Product() {Description = "doce de leite"}
        };

        public async Task<ServiceResponse<List<Product>>> GetEntireStock()
        {
            return WrapProductList(stock);
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            Product? queryResult = stock.FirstOrDefault(o => o.Id == id);
            var finalResult = WrapProduct(queryResult);

            if(finalResult.Content == null) 
            {
                finalResult.Success = false;
                finalResult.Message = "Produto não encontrado.";
            }

            return finalResult;
        }
        public async Task<List<Product>> AddNewProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Product>> RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> UpdateProduct(Product updatedProduct)
        {
            throw new NotImplementedException();
        }

        private ServiceResponse<Product> WrapProduct(Product? product)
        {
            var wrap = new ServiceResponse<Product>()
            {
                Content = product,
            };

            return wrap;
        }

        private ServiceResponse<List<Product>> WrapProductList(List<Product>? productList)
        {
            var wrap = new ServiceResponse<List<Product>>()
            {
                Content = productList,
            };

            return wrap;
        }
    }
}