using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Shop;
using System.Collections.Generic;

namespace Nothing.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetListBestProduct(int maxCount)
        {
            var response = await _context.Product.Where(a => a.Quantity > 0).Take(maxCount).ToListAsync();
            return response;
        }

        public async Task<List<Product>> GetListProduct()
        {
            var response = await _context.Product.Where(a => a.Quantity > 0).ToListAsync();
            return response;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var response = await _context.Product.Where(a => a.Id == productId).FirstAsync();
            return response;
        }

        public async Task<List<Product>> GetListProductByIds(List<Guid> listProductId)
        {
            if (listProductId == null) return new List<Product>();
            var response = await _context.Product.Where(a => listProductId.Contains(a.Id)).ToListAsync();
            return response;
        }
    }
}
