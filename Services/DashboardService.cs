using Nothing.Models;
using Nothing.Models.Api.Dashboard;
using Nothing.Models.Shop;
using Nothing.Repositories;
using System.Drawing;

namespace Nothing.Services
{
    public class DashboardService: CustomBaseService
    {
        private readonly DashboardRepository _dashboardRepo;
        private readonly OrderRepository _orderRepo;
        private readonly ProductRepository _productRepo;
        public DashboardService(ApplicationDbContext context) : base(context) 
        { 
            _dashboardRepo = new DashboardRepository(context);
            _orderRepo = new OrderRepository(context);
            _productRepo = new ProductRepository(context);
        }

        public async Task<GetInformationByBudget> GetInformationForBudget()
        {
            var listOrderByMonth = await _orderRepo.GetListOrderByMonth();

            var orderIds = listOrderByMonth.Select(a => a.Id).ToList();
            var listItemOrder = await _orderRepo.GetListItemOrderByOrderIds(orderIds);

            var response = new GetInformationByBudget()
            {
                NumberOfSales = listOrderByMonth.Count
            };


            var sumIncome = Decimal.Zero;
            var sumProfits = Decimal.Zero;
            foreach (var item in listOrderByMonth)
            {
                var listItemOrderThis = listItemOrder.Where(a => a.OrderId == item.Id).ToList();
                
                sumIncome += listItemOrderThis.Sum(a => a.Product.Price * a.Quantity);
                sumProfits += listItemOrderThis.Sum(a =>
                {
                    if (a.Product.EquityPrice == 0) return 0;
                    return (a.Product.Price - a.Product.EquityPrice) * a.Quantity;
                });
            }

            response.Income = sumIncome.ToString("###,###,###,###.00"); 
            response.Profits = sumProfits.ToString("###,###,###,###.00"); 

            return response;
        }
   
    
        public async Task<List<int>> GetCountOrderByWeek()
        {
            var listOrderByWeek = await _orderRepo.GetListOrderByWeek();

            var hoy = DateTime.Now.Date;
            var date = DateTime.Now.Date;
            date = date.AddDays(-6);

            var listOrderItem = new List<int>();

            while(date <= hoy)
            {
                var listOrderByDay = listOrderByWeek.Where(a => a.Date.Date == date.Date).Count();
                listOrderItem.Add(listOrderByDay);

                date = date.AddDays(1);
            }

            return listOrderItem;
        }

        public async Task<List<GetInfoByOrderInWeek>> GetInfoByOrderInWeek()
        {
            var listOrderByWeek = await _orderRepo.GetListOrderByWeek();
            StatusOrder[] listStatusOrder = (StatusOrder[])Enum.GetValues(typeof(StatusOrder));
            var response = new List<GetInfoByOrderInWeek>();
            int cantidadTotal = listOrderByWeek.Count;

            foreach (var item in listStatusOrder)
            {
                var listOrderByItem = listOrderByWeek.Where(a => a.Status == item).ToList();
                int cantidad = listOrderByItem.Count;

                response.Add(new GetInfoByOrderInWeek
                {
                    Name = item.ToString(),
                    Cantidad = cantidad,
                    CantidadTotal = cantidadTotal,
                });
            }

            return response;
        }

        public async Task<dynamic> GetListOfBestSellers()
        {
            var listProduct = await _orderRepo.GetListOfBestSellers();
            return listProduct;
        }


        public async Task<List<Order>> GetLastestOrder()
        {
            var listProduct = await _orderRepo.GetLastestOrder();
            return listProduct;
        }
    }
}
