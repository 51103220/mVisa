using System.Runtime.Serialization;

namespace Common.DTOs.Request.Base
{
    [DataContract]
    public class BaseRequestDto
    {
        [DataMember(Name = "transactionIdentifier")]
        public string TransactionIdentifier { get; set; }

        [DataMember(Name = "systemsTraceAuditNumber")]
        public int SystemsTraceAuditNumber { get; set; }

        [DataMember(Name = "retrievalReferenceNumber")]
        public string RetrievalReferenceNumber { get; set; }

        [DataMember(Name = "recipientPrimaryAccountNumber")]
        public string RecipientPrimaryAccountNumber { get; set; }

        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "localTransactionDateTime")]
        public string LocalTransactionDateTime { get; set; }

        [DataMember(Name = "merchantCategoryCode")]
        public int MerchantCategoryCode { get; set; }

        [DataMember(Name = "acquirerCountryCode")]
        public int AcquirerCountryCode { get; set; }

        [DataMember(Name = "acquiringBin")]
        public int AcquiringBin { get; set; }

        [DataMember(Name = "cardAcceptor")]
        public CardAcceptor CardAcceptor { get; set; } = new CardAcceptor();

        [DataMember(Name = "transactionCurrencyCode")]
        public string TransactionCurrencyCode { get; set; }

        [DataMember(Name = "businessApplicationId")]
        public string BusinessApplicationId { get; set; }

        [DataMember(Name = "senderReference")]
        public string SenderReference { get; set; }

        [DataMember(Name = "senderAccountNumber")]
        public string SenderAccountNumber { get; set; }

        [DataMember(Name = "senderName")]
        public string SenderName { get; set; }
    }
}
