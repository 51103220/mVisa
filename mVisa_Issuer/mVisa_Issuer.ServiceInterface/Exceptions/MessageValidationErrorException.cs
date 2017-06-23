namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class MessageValidationErrorException : ErrorResponseException
    {
        public MessageValidationErrorException() : base()
        {
        }

        public MessageValidationErrorException(string message) : base(message)
        {
        }
    }
}
