namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class TransactionStatusIsNotKnownException : ErrorResponseException
    {
        public TransactionStatusIsNotKnownException() : base()
        {
        }

        public TransactionStatusIsNotKnownException(string message) : base(message)
        {
        }
    }
}
