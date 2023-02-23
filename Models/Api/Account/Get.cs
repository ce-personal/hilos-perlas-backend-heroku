using Nothing.Models.Gen;
using Nothing.Models.Shared;

namespace Nothing.Models.Api.Account
{
    public class UserAdminGet
    {
        public UserAdmin? UserAdmin { get; set; }
        public Nothing.Models.Shared.File? File { get; set; }
    }
}
