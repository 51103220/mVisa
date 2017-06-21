using System.Runtime.Serialization;

namespace Common.DTOs.Advice
{
    [DataContract]
    public class AdviceMessage
    {
        [DataMember(Name = "messageType")]
        public string MessageType { get; set; }

        [DataMember(Name = "authIdResponse")]
        public string AuthIdResponse { get; set; }

        [DataMember(Name = "responseCode")]
        public string ResponseCode { get; set; }

        [DataMember(Name = "rejectionCode")]
        public string RejectionCode { get; set; }
    }
}
