using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Product;
using Nothing.Models.Shop;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class ProductService: CustomBaseService
    {
        private readonly ProductRepository _productRepo;
        public ProductService(ApplicationDbContext context) : base(context)
        {
            _productRepo = new ProductRepository(context);
        }


        public async Task<Product> Create(ProductCreate product)
        {
            var model = new Product()
            {
                CategoryId = null,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                UniquePiece = product.UniquePiece,
                Date = DateTime.Now,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
