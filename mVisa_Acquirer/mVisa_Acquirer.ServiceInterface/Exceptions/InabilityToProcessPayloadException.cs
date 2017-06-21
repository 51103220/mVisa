using System;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class InabilityToProcessPayloadException : Exception
    {
        protected InabilityToProcessPayloadException(string message) : base(message)
        {
        }
    }
}
