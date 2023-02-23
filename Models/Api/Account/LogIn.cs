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


    public class ClientResponseLogIn
    {
        public bool IsSuccess { get; set; }
        public int CodeError { get; set; }
        public Client? Client { get; set; }

        public ClientResponseLogIn NotFound()
        {
            IsSuccess = false;
            CodeError = 404;

            return this;
        }

        public ClientResponseLogIn Success(Client client)
        {
            IsSuccess = true;
            CodeError = 200;
            Client = client;

            return this;
        }


        public ClientResponseLogIn Error(int code)
        {
            IsSuccess = false;
            CodeError = code;

            return this;
        }
    }
}
