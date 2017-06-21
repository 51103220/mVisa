using Common;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public class Base64DecodingFailException : InabilityToProcessPayloadException
    {
        public Base64DecodingFailException() : base($"{Constants.EXCEPTIONS_MESSAGE.BASE_64_DECODING_FAIL}")
        { 
        }
    }
}
