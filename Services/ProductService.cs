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
            new Product() {Description = "brigadeiro", Id = 0},
            new Product() {Description = "chocolate", Id = 1},
            new Product() {Description = "doce de leite", Id = 2}
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
        public async Task<ServiceResponse<List<Product>>> AddNewProduct(Product newProduct)
        {
            stock.Add(newProduct);

            return WrapProductList(stock);
        }


        public async Task<ServiceResponse<List<Product>>> RemoveProduct(int id)
        {
            try
            {
                Product deletedProduct = stock.First(o => o.Id == id);
                stock.Remove(deletedProduct);
            }
            catch (Exception)
            {
                var finalResult = WrapProductList(stock);
                finalResult.Message = "Produto não encontrado.";
                finalResult.Success = false;
                return finalResult;
            }

            return WrapProductList(stock);
        }

        public async Task<ServiceResponse<List<Product>>> UpdateProduct(Product updatedProduct)
        {
            try
            {
                int oldProductPosition = (stock.First(o => o.Id == updatedProduct.Id)).Id;
                stock[oldProductPosition] = updatedProduct;
            }
            catch (Exception)
            {
                var finalResult = WrapProductList(stock);
                finalResult.Message = "Produto não encontrado.";
                finalResult.Success = false;
                return finalResult;
            }

            return WrapProductList(stock);
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