using Nothing.Models;
using Nothing.Models.Api.Account;
using Nothing.Models.Gen;
using Nothing.Repositories;

namespace Nothing.Services
{
    public class UserAdminService : CustomBaseService
    {
        private readonly UserAdminRepository _userAdminRepo;
        public UserAdminService(ApplicationDbContext context) : base(context)
        {
            _userAdminRepo = new UserAdminRepository(context);
        }


        public async Task<List<UserAdmin>> GetListUserAdmin()
        {
            var response = await _userAdminRepo.GetListUserAdmin();
            return response;
        }



    }
}