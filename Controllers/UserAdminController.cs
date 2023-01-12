using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Account;
using Nothing.Models.Gen;
using Nothing.Security;
using Nothing.Services;

namespace Nothing.Controllers
{
    [ApiController]
    public class UserAdminController : CustomBaseController
    {
        private readonly UserAdminService _userAdminService;
        public UserAdminController(ApplicationDbContext context) : base(context)
        {
            _userAdminService = new UserAdminService(context);
        }


        [HttpGet, Route("/UserAdmin/GetListUserAdmin")]
        public async Task<List<UserAdmin>> GetListUserAdmin()
        {
            var response = await _userAdminService.GetListUserAdmin();
            return response;
        }
    }
}
