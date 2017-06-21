
using System.Runtime.Serialization;

namespace Common.DTOs.Receive.Base
{
    [DataContract]
    public class BaseRequest
    {
        #region receive properties
        [DataMember(Name = "transactionAmount")]
        public string TransactionAmount { get; set; }

        [DataMember(Name = "transmissionDateTime")]
        public string TransmissionDateTime { get; set; }

        [DataMember(Name = "systemTraceAuditNumber")]
        public string SystemTraceAuditNumber { get; set; }

        [DataMember(Name = "localTransactionTime")]
        public string LocalTransactionTime { get; set; }

        [DataMember(Name = "localTransactionDate")]
        public string LocalTransactionDate { get; set; }

        [DataMember(Name = "originatorCountryCode")]
        public string OriginatorCountryCode { get; set; }

        [DataMember(Name = "originatorBIN")]
        public string OriginatorBIN { get; set; }

        [DataMember(Name = "retrievalReferenceNumber")]
        public string RetrievalReferenceNumber { get; set; }

        [DataMember(Name = "velocityLimitIndicator")]
        public string VelocityLimitIndicator { get; set; }

        [DataMember(Name = "transactionCurrencyCode")]
        public string TransactionCurrencyCode { get; set; }

        [DataMember(Name = "visaTransactionId")]
        public string VisaTransactionId { get; set; }

        [DataMember(Name = "decimalPositionIndicator")]
        public string DecimalPositionIndicator { get; set; }
        #endregion

        #region Advice dto
        [DataMember(Name = "messageType")]
        public string MessageType { get; set; }

        [DataMember(Name = "authIdResponse")]
        public string AuthIdResponse { get; set; }

        [DataMember(Name = "responseCode")]
        public string ResponseCode { get; set; }

        [DataMember(Name = "rejectionCode")]
        public string RejectionCode { get; set; }
        #endregion
    }
}
