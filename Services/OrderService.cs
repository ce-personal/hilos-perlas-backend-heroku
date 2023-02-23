using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Order;
using Nothing.Models.Shared;
using Nothing.Models.Shop;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class OrderService: CustomBaseService
    {

        private readonly ProductRepository _productRepo;
        private readonly OrderRepository _orderRepo;
        private readonly AccountRepository _accountRepo;
        private readonly FileRepository _fileRepo;
        public OrderService(ApplicationDbContext context): base(context) 
        {
            _productRepo = new ProductRepository(context);
            _orderRepo = new OrderRepository(context);
            _accountRepo = new AccountRepository(context);
            _fileRepo = new FileRepository(context);
        }




        public async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            var response = await _orderRepo.GetOrderByOrderId(orderId);
            return response;
        }


        public async Task<List<ItemOrderProductGet>> GetItemOrderByOrderId(Guid orderId)
        {
            var listItemOrder = await _orderRepo.GetItemOrderByOrderId(orderId);
            var listProductId = listItemOrder.Select(a => a.ProductId).ToList();
            var listFile = await _fileRepo.GetListFileByProductIds(listProductId);
            //var listFile = new List<Shared.File>();


            var response = new List<ItemOrderProductGet>();

            foreach (var item in listItemOrder)
            {
                var files = listFile.Where(a => a.ProductId == item.ProductId).ToList();
                response.Add(new ItemOrderProductGet()
                {
                    //Files = files,
                    Product = item.Product,
                    Quantity = item.Quantity
                });
            }

            return response;
        }



        public async Task<List<Order>> GetListOrderByClientId(Guid clientId)
        {
            var response = await _orderRepo.GetListOrderByClientId(clientId);
            return response;
        }

        public async Task<List<Order>> GetListOrder()
        {
            var response = await _orderRepo.GetListOrder();
            return response;
        }



        public async Task<Order> CreateOrder([FromForm] OrderPost order)
        {
            var lastRegister = await _orderRepo.GetLastOrderByClientId(order.ClientId);
            var client = await _accountRepo.GetClientById(order.ClientId);

            int consecutive = 1;

            if (lastRegister != null)
            {
                consecutive = (int)(lastRegister.Consecutive + 1);
            }


            var model = new Order
            {
                ClientId = order.ClientId,
                Date = DateTime.Now,
                DeliveryDate = order.DeliveryDate,
                Ubication = order.Ubication,
                Status = StatusOrder.Solicitado,

                Consecutive = consecutive,
                Name = $"Pedido para {client.Name} {client.LastName}"
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }


        public async Task CreateItemOrderByOrderId(ItemOrderPost itemOrder)
        {
            var model = new ItemOrder
            {
                OrderId = itemOrder.OrderId,
                ProductId = itemOrder.ProductId,
                Quantity = itemOrder.Quantity,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            var product = await _productRepo.GetProductById(itemOrder.ProductId);
            product.Quantity -= itemOrder.Quantity;

            _context.Update(product);
            await _context.SaveChangesAsync();
        }







        public async Task NextStepOrderByOrderId(Guid orderId)
        {
            var order = await _orderRepo.GetOrderByOrderId(orderId);
            order.Status += 1;

            _context.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
