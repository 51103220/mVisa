using ServiceStack;
using static Common.Constants;

namespace mVisa_Issuer.ServiceModel
{
    [Route(ISSUER.CASH_OUT_REQUEST_URL, POST)]
    [Route(ISSUER.CASH_OUT_GET_REQUEST_URL, GET)]
    public class IssuerCashOutRequest : IReturn<IssuerCashOutResponse>
    {
        public string StatusIdentifier { get; set; }
    }

    public class IssuerCashOutResponse
    {
        public string Result { get; set; }
    }
}