using AutoMapper;
using EShopping.ProductApi.DTOs;
using EShopping.ProductApi.Models;
using EShopping.ProductApi.Repositories;

namespace EShopping.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var categoryEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.Create(categoryEntity);
            productDTO.CategoryId = categoryEntity.CategoryId;
        }

        public async Task DeleteProduct(int id)
        {
            var categoryEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(categoryEntity.Id);
        }
        
        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var categoryEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.Update(categoryEntity);
        }
    }
}
