using Common.DTOs.Receive.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Receive
{
    [DataContract]
    public class CashOutBaseResponse : BaseResponse
    {
        [DataMember(Name = "authIdResponse")]
        public string AuthIdResponse { get; set; }

        [DataMember(Name = "agentName")]
        public string AgentName { get; set; }

        [DataMember(Name = "agentCity")]
        public string AgentCity { get; set; }

        [DataMember(Name = "agentCountryCode")]
        public string AgentCountryCode { get; set; }
    }
}
