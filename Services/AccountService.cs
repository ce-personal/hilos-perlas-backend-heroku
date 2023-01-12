using Nothing.Models;
using Nothing.Models.Api.Account;
using Nothing.Models.Gen;

namespace Nothing.Services
{
    public class AccountService: CustomBaseService
    {
        private readonly AccountRepository _accountRepo;
        public AccountService(ApplicationDbContext context): base(context) 
        {
            _accountRepo= new AccountRepository(context);
        }


        public async Task<ResponseLogIn> LogIn(string email, string password)
        {
            var response = new ResponseLogIn();

            var user = await _accountRepo.GetUserAdminByEmail(email);
            if (user == null) return response.NotFound();
            
            // Se acaba de registrar
            if (user.Password == null)
            {
                user.Password = password;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }


            return user.LogIn(password);
        }

        public async Task<ResponseRegister> Register(string name, string email)
        {
            var userByEmail = await _accountRepo.GetUserAdminByEmail(email);
            if (userByEmail != null) return new ResponseRegister().Error(400);

            var userAdmin = new UserAdmin()
            {
                Name = name,
                Email = email,
                Password = null,
                Date = DateTime.Now,
            };

            await _context.AddAsync(userAdmin);
            await _context.SaveChangesAsync();

            return new ResponseRegister().Success();
        }



    }
}