namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class WrongUserCredentialsException : ErrorResponseException
    {
        public WrongUserCredentialsException() : base()
        {
        }

        public WrongUserCredentialsException(string message) : base(message)
        {
        }
    }
}
