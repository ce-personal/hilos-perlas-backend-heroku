using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Shop;

namespace Nothing.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            var response = await _context.Order.Include(a => a.Client).Where(a => a.Id == orderId).FirstAsync();
            return response;
        }


        public async Task<List<ItemOrder>> GetItemOrderByOrderId(Guid orderId)
        {
            var response = await _context.ItemOrder.Where(a => a.OrderId == orderId).Include(a => a.Product).ToListAsync();
            return response;
        }






        public async Task<Order?> GetLastOrderByClientId(Guid clientId)
        {
            var response = await _context.Order.Where(a => a.ClientId == clientId).OrderBy(a => a.Date).ToListAsync();
            return response.LastOrDefault();
        }

        public async Task<List<Order>> GetLastestOrder()
        {
            var response = await _context.Order.OrderBy(a => a.Date).Take(5).ToListAsync();
            return response;
        }

        public async Task<List<Order>> GetListOrderByClientId(Guid clientId)
        {
            var response = await _context.Order.Where(a => a.ClientId == clientId).OrderBy(a => a.Date).ToListAsync();
            return response;
        }

        public async Task<List<Order>> GetListOrder()
        {
            var response = await _context.Order.OrderBy(a => a.Date).ToListAsync();
            return response;
        }

        public async Task<List<Order>> GetListOrderByMonth()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var response = await _context.Order.Where(a => a.Date.Month == month && a.Date.Year == year).ToListAsync();
            return response;
        }

        public async Task<List<Order>> GetListOrderByWeek()
        {
            var date = DateTime.Now.Date;
            date = date.AddDays(-6);

            var response = await _context.Order.Where(a => a.Date.Date >= date).ToListAsync();
            return response;
        }

        public async Task<List<ItemOrder>> GetListItemOrderByOrderIds(List<Guid> orderIds)
        {
            var response = await _context.ItemOrder
                .Where(a => orderIds.Contains(a.OrderId))
                .Include(a => a.Product)
                .ToListAsync();

            return response;
        }



        public async Task<dynamic> GetListOfBestSellers()
        {
            var response = await _context.ItemOrder
                .Include(a => a.Product)
                .GroupBy(a => new { a.Product.Id, a.Product.Name })
                .Select(a => new { Id = a.Key.Id, Name = a.Key.Name, TotalSales = a.Sum(o => o.Quantity) })
                .OrderByDescending(p => p.TotalSales)
                .Take(5)
                .ToListAsync();

            return response;
        }
    }
}
