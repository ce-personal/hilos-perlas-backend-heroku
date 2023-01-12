using Nothing.Models.Api.Account;

namespace Nothing.Models.Gen
{
    public class UserAdmin
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Date { get; set; }



        public ResponseLogIn LogIn(string password)
        {
            var isSuccess = Password == password;

            if (isSuccess) return new ResponseLogIn().Success(this);
            else return new ResponseLogIn().Error(401);
        }
    }
}
