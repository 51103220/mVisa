using Common.DTOs.Receive;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceModel
{
    [Route(ACQUIRER.ADVICE.PERSON_TO_MERCHANT_URL)]
    [DataContract]
    public class MerchantPaymentAdvice : MerchantPaymentRequest
    {
    }
}