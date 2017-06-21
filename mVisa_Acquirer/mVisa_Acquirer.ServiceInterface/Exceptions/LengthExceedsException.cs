using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class LengthExceedsException : InabilityToProcessPayloadException
    {
        public LengthExceedsException(string field, string length) : base($"{Constants.EXCEPTIONS_MESSAGE.LENGTH_EXCEEDS} - {field} - {length}")
        { 
        }
    }
}
