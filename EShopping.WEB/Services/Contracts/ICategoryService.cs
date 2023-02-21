using EShopping.WEB.Models;

namespace EShopping.WEB.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();

    }
}
