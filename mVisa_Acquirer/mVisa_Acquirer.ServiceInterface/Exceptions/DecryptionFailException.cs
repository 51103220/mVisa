using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class DecryptionFailException : InabilityToProcessPayloadException
    {
        public DecryptionFailException(string field) : base($"{Constants.EXCEPTIONS_MESSAGE.DECRYPTION_FIELDS_FAIL} - {field}")
        { 
        }
    }
}
