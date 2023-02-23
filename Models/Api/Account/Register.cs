using Nothing.Models.Gen;

namespace Nothing.Models.Api.Account
{
    public class ResponseRegister
    {
        public bool IsSuccess { get; set; }
        public int CodeError { get; set; }
        public Client? Client { get; set; }
        public UserAdmin? UserAdmin { get; set; }

        public ResponseRegister Error(int code)
        {
            CodeError = code;

            return this;
        }

        public ResponseRegister Success()
        {
            IsSuccess = true;
            return this;
        }
    }

    public class UserRegister
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
