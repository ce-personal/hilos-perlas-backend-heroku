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

        [HttpPost, Route("/Product/Edit")]
        public async Task<Product> Edit([FromForm] ProductEdit product)
        {
            var response = await _productService.Edit(product);
            return response;
        }

        [HttpGet, Route("/Product/GetListProduct")]
        public async Task<List<ProductGet>> GetListProduct()
        {
            var response = await _productService.GetListProduct();
            return response;
        }

        [HttpGet, Route("/Product/GetProductById")]
        public async Task<ProductGet> GetProductById(Guid productId)
        {
            var response = await _productService.GetProductById(productId);
            return response;
        }



        [HttpGet, Route("/Product/GetListBestProduct")]
        public async Task<List<ProductGet>> GetListBestProduct()
        {
            var response = await _productService.GetListBestProduct();
            return response;
        }


        [HttpPost, Route("/Product/GetProductByListId")]
        public async Task<List<ProductGet>> GetProductByListId([FromForm]List<Guid> listProductId)
        {
            var response = await _productService.GetProductByListId(listProductId);
            return response;
        }
    }
}
