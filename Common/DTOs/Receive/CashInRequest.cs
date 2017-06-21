using Common.DTOs.Receive.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Receive
{
    [DataContract]
    public class CashInRequest : BaseRequest
    {
        [DataMember(Name = "encConsumerPAN")]
        public string EncConsumerPAN { get; set; }

        [DataMember(Name = "encAgentName")]
        public string EncAgentName { get; set; }
    }
}
