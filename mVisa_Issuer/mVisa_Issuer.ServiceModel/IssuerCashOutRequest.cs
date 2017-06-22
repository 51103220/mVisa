using Common.DTOs.Request;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Issuer.ServiceModel
{
    [Route(ISSUER.CASH_OUT_REQUEST_URL, POST)]
    [DataContract]
    public class IssuerCashOutRequest : CashOutRequestDto, IReturn<IssuerCashOutResponse>
    {
    }

    public class IssuerCashOutResponse
    {
        public string Result { get; set; }
    }
}