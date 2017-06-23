namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class NetworkConnectivityTimeoutException : ErrorResponseException
    {
        public NetworkConnectivityTimeoutException() : base()
        {
        }

        public NetworkConnectivityTimeoutException(string message) : base(message)
        {
        }
    }
}
