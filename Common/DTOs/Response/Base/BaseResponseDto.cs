using System.Runtime.Serialization;

namespace Common.DTOs.Response.Base
{
    [DataContract]
    public class BaseResponseDto
    {
        [DataMember(Name = "transactionIdentifier")]
        public int TransactionIdentifier { get; set; }

        [DataMember(Name = "retrievalReferenceNumber")]
        public string RetrievalReferenceNumber { get; set; }

        [DataMember(Name = "approvalCode")]
        public string ApprovalCode { get; set; }

        [DataMember(Name = "actionCode")]
        public string ActionCode { get; set; }

        [DataMember(Name = "responseCode")]
        public string ResponseCode { get; set; }

        [DataMember(Name = "statusIdentifier")]
        public string StatusIdentifier { get; set; }
    }
}
