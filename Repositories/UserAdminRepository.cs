using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nothing.Models;
using Nothing.Models.Gen;

namespace Nothing.Repositories
{
    public class UserAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public UserAdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<UserAdmin>> GetListUserAdmin()
        {
            var response = await _context.UserAdmin.ToListAsync();

            return response;
        }
    }
}
