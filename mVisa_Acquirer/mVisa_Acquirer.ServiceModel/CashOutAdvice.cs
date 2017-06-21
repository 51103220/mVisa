using Common.DTOs.Receive;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceModel
{
    [Route(ACQUIRER.ADVICE.CASH_OUT_URL)]
    [DataContract]
    public class CashOutAdvice : CashOutRequest
    {
    }
}