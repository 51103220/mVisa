using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class InvalidFieldFormatException : InabilityToProcessPayloadException
    {
        public InvalidFieldFormatException(string field, string realValue) : base($"{Constants.EXCEPTIONS_MESSAGE.INVALID_FIELD_FORMAT} - {field} - {realValue}")
        { 
        }
    }
}
