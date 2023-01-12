namespace Nothing.Models.Api.Account
{
    public class ResponseRegister
    {
        public bool IsSuccess { get; set; }
        public int CodeError { get; set; }

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
}
