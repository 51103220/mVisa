using Common.DTOs.Receive.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Receive
{
    [DataContract]
    public class CashOutRequest : BaseRequest
    {
        [DataMember(Name = "encAgentPAN")]
        public string EncAgentPAN { get; set; }

        [DataMember(Name = "encConsumerPAN")]
        public string EncConsumerPAN { get; set; }

        [DataMember(Name = "encConsumerName")]
        public string EncConsumerName { get; set; }
    }
}
