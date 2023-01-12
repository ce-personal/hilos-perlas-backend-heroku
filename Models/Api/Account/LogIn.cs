using Nothing.Models.Gen;

namespace Nothing.Models.Api.Account
{
    public class ResponseLogIn
    {
        public bool IsSuccess { get; set; }
        public int CodeError { get; set; }
        public UserAdmin? UserAdmin { get; set; }

        public ResponseLogIn NotFound()
        {
            IsSuccess = false;
            CodeError = 404;

            return this;
        }

        public ResponseLogIn Success(UserAdmin userAdmin) 
        { 
            IsSuccess = true;
            CodeError = 200;
            UserAdmin = userAdmin;
        
            return this;
        }


        public ResponseLogIn Error(int code) 
        { 
            IsSuccess = false;
            CodeError = code;

            return this;
        }
    }
}
