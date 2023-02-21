using EShopping.ProductApi.DTOs;
using EShopping.ProductApi.Models;

namespace EShopping.ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(ProductDTO productDTO);
        Task DeleteProduct(int id);
    }
}
