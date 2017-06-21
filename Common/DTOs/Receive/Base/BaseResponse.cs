
using System.Runtime.Serialization;

namespace Common.DTOs.Receive.Base
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember(Name = "receiverTransactionId")]
        public string ReceiverTransactionId { get; set; }

        [DataMember(Name = "responseCode")]
        public string ResponseCode { get; set; }

        [DataMember(Name = "responseMessage")]
        public string ResponseMessage { get; set; }
    }
}
