using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class TypeMismatchException : InabilityToProcessPayloadException
    {
        public TypeMismatchException(string field, string realValue) : base($"{Constants.EXCEPTIONS_MESSAGE.TYPE_MISMATCH} - {field} - {realValue}")
        { 
        }
    }
}
