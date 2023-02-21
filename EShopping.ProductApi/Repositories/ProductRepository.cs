using EShopping.ProductApi.Context;
using EShopping.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopping.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }   
        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(c => c.Category).Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Product> Create(Product category)
        {
            _context.Products.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetById(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
