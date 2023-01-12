using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nothing.Models;
using Nothing.Models.Api.Account;
using Nothing.Security;
using Nothing.Services;

namespace Nothing.Controllers
{
    [ApiController]
    public class AccountController : CustomBaseController
    {
        private readonly AccountService _accountService;
        public AccountController(ApplicationDbContext context): base(context) 
        {
            _accountService = new AccountService(context);
        }


        [HttpPost, Route("/Account/LogIn")]
        public async Task<ResponseLogIn> LogIn(string email, string password)
        {
            var response = await _accountService.LogIn(email, password);
            return response;
        }

        [HttpPost, Route("/Account/Register")]
        public async Task<ResponseRegister> Register(string name, string email)
        {
            var response = await _accountService.Register(name, email);
            return response;
        }
    }
}
