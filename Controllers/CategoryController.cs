using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Category;
using Nothing.Models.Gen;
using Nothing.Services;

namespace Nothing.Controllers
{
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly CategoryService _categoryService;
        public CategoryController(ApplicationDbContext context) : base(context)
        {
            _categoryService = new CategoryService(context);
        }


        [HttpGet, Route("/Category/GetListCategory")]
        public async Task<List<Category>> GetListCategory()
        {
            var response = await _categoryService.GetListCategory();
            return response;
        }

        [HttpPost, Route("/Category/Create")]
        public async Task Create([FromForm]CategoryPost category)
        {
            await _categoryService.CreateCategory(category);
        }

        [HttpGet, Route("/Category/GetCategoryById")]
        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            var response = await _categoryService.GetCategoryById(categoryId);
            return response;
        }

        [HttpPut, Route("/Category/Edit")]
        public async Task Edit([FromForm] CategoryPut category)
        {
            await _categoryService.EditCategory(category);
        }

        [HttpDelete, Route("/Category/Delete")]
        public async Task Delete(Guid categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
        }
    }
}
