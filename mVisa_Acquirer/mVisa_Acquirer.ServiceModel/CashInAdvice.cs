using Common.DTOs.Receive;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceModel
{
    [Route(ACQUIRER.ADVICE.CASH_IN_URL)]
    [DataContract]
    public class CashInAdvice : CashInRequest
    { 
    }
}