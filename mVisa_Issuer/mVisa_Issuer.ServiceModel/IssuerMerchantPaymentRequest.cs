using Common.DTOs.Request;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Issuer.ServiceModel
{
    [Route(ISSUER.MERCHANT_PAYMENT_REQUEST_URL, POST)]
    [DataContract]
    public class IssuerMerchantPaymentRequest : MerchantPaymentRequestDto, IReturn<IssuerMerchantPaymentResponse>
    {
    }

    public class IssuerMerchantPaymentResponse
    {
        public string Result { get; set; }
    }
}