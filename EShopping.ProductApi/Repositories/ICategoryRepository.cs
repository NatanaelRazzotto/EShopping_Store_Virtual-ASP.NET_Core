using EShopping.ProductApi.Models;

namespace EShopping.ProductApi.Repositories;
public interface ICategoryRepository
{
    //Um repositorio é uma coleção de objetos de dominio, objetos na memoria, não um DTO!
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetCategoriesProducts();
    Task<Category> GetById(int id);
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);


}
