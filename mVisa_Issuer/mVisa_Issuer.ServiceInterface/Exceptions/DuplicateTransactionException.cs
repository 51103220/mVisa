namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class DuplicateTransactionException : ErrorResponseException
    {
        public DuplicateTransactionException() : base()
        {
        }

        public DuplicateTransactionException(string message) : base(message)
        {
        }
    }
}
