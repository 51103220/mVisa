namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class InvalidPrimaryAccountNumberException : ErrorResponseException
    {
        public InvalidPrimaryAccountNumberException() : base()
        {
        }

        public InvalidPrimaryAccountNumberException(string message) : base(message)
        {
        }
    }
}
