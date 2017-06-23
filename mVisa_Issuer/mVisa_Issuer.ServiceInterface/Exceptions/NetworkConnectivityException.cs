namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class NetworkConnectivityException : ErrorResponseException
    {
        public NetworkConnectivityException() : base()
        {
        }

        public NetworkConnectivityException(string message) : base(message)
        {
        }
    }
}
