using ServiceStack;
using static Common.Constants;

namespace mVisa_Issuer.ServiceModel
{
    [Route(ISSUER.MERCHANT_PAYMENT_REQUEST_URL, POST)]
    [Route(ISSUER.MERCHANT_PAYMENT_GET_REQUEST_URL, GET)]
    public class IssuerMerchantPaymentRequest : IReturn<IssuerMerchantPaymentResponse>
    {
        public string StatusIdentifier { get; set; }
    }

    public class IssuerMerchantPaymentResponse
    {
        public string Result { get; set; }
    }
}