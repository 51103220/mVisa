using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class InvalidJsonException : InabilityToProcessPayloadException
    {
        public InvalidJsonException() : base($"{Constants.EXCEPTIONS_MESSAGE.INVALID_JSON}")
        { 
        }
    }
}
