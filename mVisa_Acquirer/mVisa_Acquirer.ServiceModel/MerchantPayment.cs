using Common.DTOs.Receive;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceModel
{
    [Route(ACQUIRER.RECEIVE.PERSON_TO_MERCHANT_URL)]
    [DataContract]
    public class MerchantPayment : MerchantPaymentRequest, IReturn<MerchantPaymentResponse>
    {
    }
    [DataContract]
    public class MerchantPaymentResponse : MerchantPaymentBaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
    }
}