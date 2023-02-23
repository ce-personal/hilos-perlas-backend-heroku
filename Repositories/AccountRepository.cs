using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Gen;

namespace Nothing.Services
{
    public class AccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<UserAdmin?> GetUserAdminByEmail(string email) 
        {
            var resultado = await _context.UserAdmin
                .Where(a => a.Email == email)
                .FirstOrDefaultAsync();

            return resultado;
        }

        public async Task<Client?> GetClientByEmail(string email)
        {
            var resultado = await _context.Client
                .Where(a => a.Email == email)
                .FirstOrDefaultAsync();

            return resultado;
        }

        public async Task<UserAdmin?> GetUserAdminById(Guid userAdminId)
        {
            var resultado = await _context.UserAdmin
                .Where(a => a.Id == userAdminId)
                .FirstOrDefaultAsync();

            return resultado;
        }

        public async Task<Client?> GetClientById(Guid clientId)
        {
            var resultado = await _context.Client
                .Where(a => a.Id == clientId)
                .FirstOrDefaultAsync();

            return resultado;
        }

    }
}