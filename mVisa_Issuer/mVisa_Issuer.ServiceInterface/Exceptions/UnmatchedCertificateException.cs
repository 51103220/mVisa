namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class UnmatchedCertificateException : ErrorResponseException
    {
        public UnmatchedCertificateException() : base()
        {
        }

        public UnmatchedCertificateException(string message) : base(message)
        {
        }
    }
}
