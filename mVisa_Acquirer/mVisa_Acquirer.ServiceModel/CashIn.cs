using Common.DTOs.Receive;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceModel
{
    [Route(ACQUIRER.RECEIVE.CASH_IN_URL)]
    [DataContract]
    public class CashIn : CashInRequest, IReturn<CashInResponse>
    {
    }
    [DataContract]
    public class CashInResponse : CashInBaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
    }
}