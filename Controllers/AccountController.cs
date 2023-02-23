using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Api.Account;
using Nothing.Models.Gen;
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

        [HttpGet, Route("/Account/Profiles")]
        public async Task<List<UserAdmin>> Profiles()
        {
            var listProfiles = await _context.UserAdmin.ToListAsync();
            return listProfiles;
        }


        [HttpPost, Route("/Account/LogIn")]
        public async Task<ResponseLogIn> LogIn(string email, string password)
        {
            var response = await _accountService.LogIn(email, password);
            return response;
        }

        [HttpPost, Route("/Account/Client/LogIn")]
        public async Task<ClientResponseLogIn> ClientLogin(string email, string password)
        {
            var response = await _accountService.ClientLogIn(email, password);
            return response;
        }
        
        
        
        
        
        [HttpPost, Route("/Account/Register")]
        public async Task<ResponseRegister> Register(string firstName, string lastName, string email)
        {
            var response = await _accountService.Register(firstName, lastName, email);
            return response;
        }

        [HttpPost, Route("/Account/Client/Register")]
        public async Task<ResponseRegister> ClientRegister([FromForm] UserRegister user)
        {
            var response = await _accountService.ClientRegister(user);
            return response;
        }






        [HttpGet, Route("/Account/GetProfileById")]
        public async Task<UserAdminGet> GetProfileById(Guid userAdminId)
        {
            var response = await _accountService.GetProfileById(userAdminId);
            return response;
        }

        
        
        [HttpGet, Route("/Account/Client/GetProfileById")]
        public async Task<Client> GetProfileClientById(Guid clientId)
        {
            var response = await _accountService.GetProfileClientById(clientId);
            return response;
        }





        [HttpPost, Route("/Account/PostProfileByEdit")]
        public async Task PostProfileByEdit([FromForm]UserAdminPost userAdmin)
        {
            await _accountService.PostProfileByEdit(userAdmin);
        }

        [HttpPost, Route("/Account/Client/PostProfileByEdit")]
        public async Task PostClientProfileByEdit([FromForm] ClientPost client)
        {
            await _accountService.PostClientProfileByEdit(client);
        }
    }
}
