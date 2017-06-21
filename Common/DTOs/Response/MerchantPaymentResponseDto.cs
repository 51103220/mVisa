using Common.DTOs.Request;
using Common.DTOs.Response.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Response
{
    [DataContract]
    public class MerchantPaymentResponseDto : BaseResponseDto
    {
        [DataMember(Name = "transmissionDateTime")]
        public string TransmissionDateTime { get; set; }

        [DataMember(Name = "merchantCategoryCode")]
        public string MerchantCategoryCode { get; set; }

        [DataMember(Name = "cardAcceptor")]
        public CardAcceptor CardAcceptor { get; set; } = new CardAcceptor();

        [DataMember(Name = "purchaseIdentifier")]
        public PurchaseIdentifier PurchaseIdentifier { get; set; } = new PurchaseIdentifier();

        [DataMember(Name = "merchantVerificationValue")]
        public string MerchantVerificationValue { get; set; }

        [DataMember(Name = "feeProgramIndicator")]
        public string FeeProgramIndicator { get; set; }
    }
}
