using Nothing.Models;
using Nothing.Models.Api.Category;
using Nothing.Models.Gen;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class CategoryService: CustomBaseService
    {
        private readonly CategoryRepository _categoryRepo;
        public CategoryService(ApplicationDbContext context) : base(context)
        {
            _categoryRepo = new CategoryRepository(context);
        }

        public async Task<List<Category>> GetListCategory()
        {
            var response = await _categoryRepo.GetListCategory();
            return response;
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            var response = await _categoryRepo.GetCategoryById(categoryId);
            return response;
        }

        public async Task CreateCategory(CategoryPost category)
        {
            var model = new Category()
            {
                Date = DateTime.Now,
                Name = category.Name,
                Description = category.Description,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task EditCategory(CategoryPut category)
        {
            var model = await _categoryRepo.GetCategoryById(category.Id);
            model.Name = category.Name;
            model.Description = category.Description;

            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var model = await _categoryRepo.GetCategoryById(categoryId);
            
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
