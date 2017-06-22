using Common.DTOs.Request.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Request
{
    [DataContract]
    public class MerchantPaymentRequestDto : BaseRequestDto
    {
        [DataMember(Name = "transactionFeeAmt")]
        public string TransactionFeeAmt { get; set; }

        [DataMember(Name = "purchaseIdentifier")]
        public PurchaseIdentifier PurchaseIdentifier { get; set; } = new PurchaseIdentifier();

        [DataMember(Name = "secondaryId")]
        public string SecondaryId { get; set; }

        [DataMember(Name = "feeProgramIndicator")]
        public string FeeProgramIndicator { get; set; }

        [DataMember(Name = "recipientName")]
        public string RecipientName { get; set; }
    }
}
