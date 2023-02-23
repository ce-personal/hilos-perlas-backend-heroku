using Nothing.Models;
using Nothing.Models.Api.Account;
using Nothing.Models.Gen;
using Nothing.Models.Shared;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class AccountService: CustomBaseService
    {
        private readonly AccountRepository _accountRepo;
        private readonly FileRepository _fileRepo;
        public AccountService(ApplicationDbContext context): base(context) 
        {
            _accountRepo= new AccountRepository(context);
            _fileRepo = new FileRepository(context);
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

        public async Task<ClientResponseLogIn> ClientLogIn(string email, string password)
        {
            var response = new ClientResponseLogIn();

            var user = await _accountRepo.GetClientByEmail(email);
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


        




        public async Task<ResponseRegister> Register(string firstName, string lastName, string email)
        {
            var userByEmail = await _accountRepo.GetUserAdminByEmail(email);
            if (userByEmail != null) return new ResponseRegister().Error(400);

            var userAdmin = new UserAdmin()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = null,
                Date = DateTime.Now,
            };

            await _context.AddAsync(userAdmin);
            await _context.SaveChangesAsync();

            return new ResponseRegister().Success();
        }

        public async Task<ResponseRegister> ClientRegister(UserRegister user)
        {
            var userByEmail = await _accountRepo.GetClientByEmail(user.Email);
            if (userByEmail != null) return new ResponseRegister().Error(400);

            var model = new Client()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
            };

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            var response = new ResponseRegister().Success();
            response.Client = model;

            return response;
        }


        
        
        
        public async Task<UserAdminGet> GetProfileById(Guid userAdminId)
        {
            var userAdmin = await _accountRepo.GetUserAdminById(userAdminId);
            var files = await _fileRepo.GetListFileByUserAdminId(userAdminId);
            
            var model = new UserAdminGet(); 
            model.UserAdmin = userAdmin;
            model.File = files.FirstOrDefault();

            return model;
        }

        public async Task<Client> GetProfileClientById(Guid clientId)
        {
            var model = await _accountRepo.GetClientById(clientId);
            return model;
        }





        public async Task PostProfileByEdit(UserAdminPost userAdmin)
        {
            var model = await _accountRepo.GetUserAdminById(userAdmin.Id);
            if (model == null) return;

            model.PhoneNumber = userAdmin.PhoneNumber;
            model.Email = userAdmin.Email;
            model.FirstName = userAdmin.FirstName;
            model.LastName = userAdmin.LastName;
            model.Password = userAdmin.Password;

            _context.Update(model);
            await _context.SaveChangesAsync();


            var file = await _fileRepo.GetListFileByUserAdminId(userAdmin.Id);
            _context.RemoveRange(file);
            await _context.SaveChangesAsync();
        }
        
        public async Task PostClientProfileByEdit(ClientPost client)
        {
            var model = await _accountRepo.GetClientById(client.Id);
            if (model == null) return;

            model.PhoneNumber = client.PhoneNumber;
            model.Email = client.Email;
            model.Name = client.Name;
            model.LastName = client.LastName;
            model.Password = client.Password;
            model.FileString = client.FileString;

            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}