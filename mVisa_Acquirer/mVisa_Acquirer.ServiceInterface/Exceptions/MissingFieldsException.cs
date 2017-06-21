using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class MissingFieldsException : InabilityToProcessPayloadException
    {
        public MissingFieldsException(string field) : base($"{Constants.EXCEPTIONS_MESSAGE.MISSING_FIELDS} - {field}")
        { 
        }
    }
}
