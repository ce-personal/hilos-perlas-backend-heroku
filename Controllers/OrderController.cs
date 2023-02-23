using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Order;
using Nothing.Models.Shop;
using Nothing.Services;

namespace Nothing.Controllers
{
    public class OrderController : CustomBaseController
    {
        private readonly OrderService _orderService;
        public OrderController(ApplicationDbContext context) : base(context) 
        {
            _orderService = new OrderService(context);
        }


        [HttpPost, Route("/Order/CreateOrder")]
        public async Task<Order> CreateOrder([FromForm] OrderPost order)
        {
            var response = await _orderService.CreateOrder(order);
            return response;
        }


        [HttpPost, Route("/Order/CreateItemOrderByOrderId")]
        public async Task CreateItemOrderByOrderId([FromForm] ItemOrderPost itemOrder)
        {
            await _orderService.CreateItemOrderByOrderId(itemOrder);
        }


        [HttpGet, Route("/Order/GetListOrderByClientId")]
        public async Task<List<Order>> GetListOrderByClientId(Guid clientId)
        {
            var response = await _orderService.GetListOrderByClientId(clientId);
            return response;
        }




        [HttpGet, Route("/Order/GetOrderByOrderId")]
        public async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            var response = await _orderService.GetOrderByOrderId(orderId);
            return response;
        }

        [HttpGet, Route("/Order/GetItemOrderByOrderId")]
        public async Task<List<ItemOrderProductGet>> GetItemOrderByOrderId(Guid orderId)
        {
            var response = await _orderService.GetItemOrderByOrderId(orderId);
            return response;
        }

        [HttpGet, Route("/Order/GetListOrder")]
        public async Task<List<Order>> GetListOrder()
        {
            var response = await _orderService.GetListOrder();
            return response;
        }

        [HttpPost, Route("/Order/NextStepOrderByOrderId")]
        public async Task NextStepOrderByOrderId(Guid orderId)
        {
            await _orderService.NextStepOrderByOrderId(orderId);
        }

    }
}
