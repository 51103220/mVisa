using Common.DTOs.Receive;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceModel
{
    [Route(ACQUIRER.RECEIVE.CASH_OUT_URL)]
    [DataContract]
    public class CashOut : CashOutRequest, IReturn<CashOutResponse>
    {
    }
    [DataContract]
    public class CashOutResponse : CashOutBaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
    }
}