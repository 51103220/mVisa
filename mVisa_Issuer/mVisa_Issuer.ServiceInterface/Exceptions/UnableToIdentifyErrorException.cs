namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class UnableToIdentifyErrorException : ErrorResponseException
    {
        public UnableToIdentifyErrorException() : base()
        {
        }

        public UnableToIdentifyErrorException(string message) : base(message)
        {
        }
    }
}
