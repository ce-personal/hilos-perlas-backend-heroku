using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Gen;

namespace Nothing.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetListCategory()
        {
            var response = await _context.Category.ToListAsync();
            return response;
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            var response = await _context.Category.FindAsync(categoryId);
            return response;
        }
    }
}
