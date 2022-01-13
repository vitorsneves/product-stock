using AutoMapper;
using Domain.DTO;
using Domain.Model;
using Persistence;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper) 
        {
            _mapper = mapper;
        }

        private List<Product> stock = new List<Product>()
        {
            new Product() {Description = "brigadeiro", Id = 0},
            new Product() {Description = "chocolate", Id = 1},
            new Product() {Description = "doce de leite", Id = 2}
        };

        public async Task<ServiceResponse<List<GetProductDTO>>> GetEntireStock()
        {
            return WrapProductList(stock.Select(o => _mapper.Map<GetProductDTO>(o)).ToList());
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            Product? queryResult = stock.FirstOrDefault(o => o.Id == id);

            var finalResult = WrapProduct(_mapper.Map<GetProductDTO>(queryResult));
            if(finalResult.Content == null) 
            {
                finalResult.Success = false;
                finalResult.Message = "Produto não encontrado.";
            }

            return finalResult;
        }
        public async Task<ServiceResponse<List<GetProductDTO>>> AddNewProduct(AddProductDTO newProduct)
        {
            stock.Add(_mapper.Map<Product>(newProduct));

            return WrapProductList(stock.Select(o => _mapper.Map<GetProductDTO>(o)).ToList());
        }


        public async Task<ServiceResponse<List<GetProductDTO>>> RemoveProduct(int id)
        {
            var finalResult = new ServiceResponse<List<GetProductDTO>> ();
            try
            {
                Product deletedProduct = stock.First(o => o.Id == id);
                stock.Remove(deletedProduct);

                finalResult = WrapProductList(stock.Select(o => _mapper.Map<GetProductDTO>(o)).ToList());
            }
            catch (Exception)
            {
                finalResult.Message = "Produto não encontrado.";
                finalResult.Success = false;
            }

            return finalResult;
        }

        public async Task<ServiceResponse<List<GetProductDTO>>> UpdateProduct(UpdateProductDTO updatedProduct)
        {
            var finalResult = new ServiceResponse<List<GetProductDTO>> ();
            try
            {
                int oldProductPosition = (stock.First(o => o.Id == updatedProduct.Id)).Id;
                stock[oldProductPosition] = _mapper.Map<Product>(updatedProduct);
                
                finalResult = WrapProductList(stock.Select(o => _mapper.Map<GetProductDTO>(o)).ToList());
            }
            catch (Exception)
            {
                finalResult.Message = "Produto não encontrado.";
                finalResult.Success = false;
            }

            return finalResult;
        }

        private ServiceResponse<GetProductDTO> WrapProduct(GetProductDTO? product)
        {
            var wrap = new ServiceResponse<GetProductDTO>()
            {
                Content = product,
            };

            return wrap;
        }

        private ServiceResponse<List<GetProductDTO>> WrapProductList(List<GetProductDTO>? productList)
        {
            var wrap = new ServiceResponse<List<GetProductDTO>>()
            {
                Content = productList,
            };

            return wrap;
        }
    }
}