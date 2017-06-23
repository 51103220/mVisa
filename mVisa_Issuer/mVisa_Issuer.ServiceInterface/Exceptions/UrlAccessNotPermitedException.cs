namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class UrlAccessNotPermitedException : ErrorResponseException
    {
        public UrlAccessNotPermitedException() : base()
        {
        }

        public UrlAccessNotPermitedException(string message) : base(message)
        {
        }
    }
}
