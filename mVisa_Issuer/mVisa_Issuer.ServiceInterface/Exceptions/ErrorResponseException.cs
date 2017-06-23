using System;

namespace mVisa_Issuer.ServiceInterface.Exceptions
{
    public class ErrorResponseException : Exception
    {
        protected ErrorResponseException() : base()
        {
        }

        protected ErrorResponseException(string message) : base(message)
        {
        }
    }
}
