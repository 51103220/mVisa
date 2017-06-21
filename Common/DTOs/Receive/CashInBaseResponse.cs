using Common.DTOs.Receive.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Receive
{
    [DataContract]
    public class CashInBaseResponse : BaseResponse
    {
        [DataMember(Name = "authIdResponse")]
        public string AuthIdResponse { get; set; }
    }
}
