using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Product;
using Nothing.Models.Shop;
using Nothing.Services;

namespace Nothing.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly ProductService _productService;
        public ProductController(ApplicationDbContext context) : base(context)
        {
            _productService = new ProductService(context);
        }


        [HttpPost, Route("/Product/Create")]
        public async Task<Product> Create([FromForm]ProductCreate product)
        {
            var response = await _productService.Create(product);
            return response;
        }
    }
}
