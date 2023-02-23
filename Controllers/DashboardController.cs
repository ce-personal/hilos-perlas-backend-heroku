using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Dashboard;
using Nothing.Models.Shop;
using Nothing.Services;

namespace Nothing.Controllers
{
    [ApiController]
    public class DashboardController : CustomBaseController
    {
        private readonly DashboardService _dashboardService;
        public DashboardController(ApplicationDbContext context) : base(context)
        {
            _dashboardService = new DashboardService(context);
        }


        [HttpGet, Route("/Dashboard/GetInformationForBudget")]
        public async Task<GetInformationByBudget> GetInformationForBudget()
        {
            var response = await _dashboardService.GetInformationForBudget();
            return response;
        }


        [HttpGet, Route("/Dashboard/GetCountOrderByWeek")]
        public async Task<List<int>> GetCountOrderByWeek()
        {
            var response = await _dashboardService.GetCountOrderByWeek();
            return response;
        }

        [HttpGet, Route("/Dashboard/GetInfoByOrderInWeek")]
        public async Task<List<GetInfoByOrderInWeek>> GetInfoByOrderInWeek()
        {
            var response = await _dashboardService.GetInfoByOrderInWeek();
            return response;
        }
        
        [HttpGet, Route("/Dashboard/GetListOfBestSellers")]
        public async Task<dynamic> GetListOfBestSellers()
        {
            var response = await _dashboardService.GetListOfBestSellers();
            return response;
        }

        [HttpGet, Route("/Dashboard/GetLastestOrder")]
        public async Task<List<Order>> GetLastestOrder()
        {
            var response = await _dashboardService.GetLastestOrder();
            return response;
        }
    }
}
