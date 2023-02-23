using Nothing.Models.Api.Account;

namespace Nothing.Models.Gen
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? FileString { get; set; }


        public ClientResponseLogIn LogIn(string password)
        {
            var isSuccess = Password == password;

            if (isSuccess) return new ClientResponseLogIn().Success(this);
            else return new ClientResponseLogIn().Error(401);
        }
    }
}
