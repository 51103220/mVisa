namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class UrlNotExistsException : ErrorResponseException
    {
        public UrlNotExistsException() : base()
        {
        }

        public UrlNotExistsException(string message) : base(message)
        {
        }
    }
}
