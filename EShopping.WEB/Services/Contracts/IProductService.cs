using EShopping.WEB.Models;

namespace EShopping.WEB.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> FindProductById(int id);
        Task<ProductViewModel> CreateProduct(ProductViewModel productVM);
        Task<ProductViewModel> UpdateProduct(ProductViewModel productVM);
        Task<ProductViewModel> DeleteProductById(int id);
    }
}
