namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class TimeOutResponseException : ErrorResponseException
    {
        public TimeOutResponseException() : base()
        {
        }

        public TimeOutResponseException(string message) : base(message)
        {
        }
    }
}
