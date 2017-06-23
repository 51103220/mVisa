namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class GETRequestHasBeenSentException : ErrorResponseException
    {
        public GETRequestHasBeenSentException() : base()
        {
        }

        public GETRequestHasBeenSentException(string message) : base(message)
        {
        }
    }
}
