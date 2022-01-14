using AutoMapper;
using Domain.DTO;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ProductService(IMapper mapper, DataContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        // private List<Product> stock = new List<Product>()
        // {
        //     new Product() {Description = "brigadeiro", Id = 0},
        //     new Product() {Description = "chocolate", Id = 1},
        //     new Product() {Description = "doce de leite", Id = 2}
        // };

        public async Task<ServiceResponse<List<GetProductDTO>>> GetEntireStock()
        {
            return WrapProductList(await _context.Products.Select(
                o => _mapper.Map<GetProductDTO>(o)).ToListAsync()
            );
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
        {
            Product? queryResult = await _context.Products.FirstOrDefaultAsync(o => o.Id == id);

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
            _context.Products.Add(_mapper.Map<Product>(newProduct));
            _context.SaveChanges();

            return WrapProductList(await _context.Products.Select(
                o => _mapper.Map<GetProductDTO>(o)).ToListAsync()
            );
        }


        public async Task<ServiceResponse<List<GetProductDTO>>> RemoveProduct(int id)
        {
            var finalResult = new ServiceResponse<List<GetProductDTO>> ();
            try
            {
                Product deletedProduct = _context.Products.First(o => o.Id == id);
                _context.Products.Remove(deletedProduct);
                _context.SaveChanges();

                finalResult = WrapProductList(await _context.Products.Select(
                    o => _mapper.Map<GetProductDTO>(o)).ToListAsync()
                );
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
                Product oldProduct = (_context.Products.First(o => o.Id == updatedProduct.Id));
                Product newProduct = _mapper.Map<Product>(updatedProduct);

                oldProduct.Description = newProduct.Description;
                oldProduct.Price = newProduct.Price;
                oldProduct.Quantity = newProduct.Quantity;
                
                _context.SaveChanges();

                finalResult = WrapProductList(await _context.Products.Select(o => _mapper.Map<GetProductDTO>(o)).ToListAsync());
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