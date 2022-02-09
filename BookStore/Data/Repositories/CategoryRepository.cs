using BookStore.Context;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBContext _context;
        public CategoryRepository(DBContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Create(Category category)
        {
            try
            {
                _context.Categories.Add(category);

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public virtual async Task<bool> Update(Category category)
        {
            try
            {
                _context.Categories.Update(category);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<bool> Delete(int? id)
        {
            try
            {
                _context.Categories.Remove(await _context.Categories.FindAsync(id));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<List<Category>> Get(int skip = 0, int take = 25)
        {
            // View(await _context.Categories.ToListAsync());
            return await _context.Categories.OrderBy(x => x.Name).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<Category> GetById(int? id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}
