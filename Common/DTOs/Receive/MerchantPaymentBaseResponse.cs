using Common.DTOs.Receive.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Receive
{
    [DataContract]
    public class MerchantPaymentBaseResponse : BaseResponse
    {
        [DataMember(Name = "merchantCategoryCode")]
        public string MerchantCategoryCode { get; set; }

        [DataMember(Name = "authIdResponse")]
        public string AuthIdResponse { get; set; }

        [DataMember(Name = "merchantName")]
        public string MerchantName { get; set; }

        [DataMember(Name = "merchantCity")]
        public string MerchantCity { get; set; }

        [DataMember(Name = "merchantCountryCode")]
        public string MerchantCountryCode { get; set; }

        [DataMember(Name = "merchantTerminalID")]
        public string MerchantTerminalID { get; set; }

        [DataMember(Name = "merchantID")]
        public string MerchantID { get; set; }

        [DataMember(Name = "merchantVerificationValue")]
        public string MerchantVerificationValue { get; set; }

        [DataMember(Name = "feeProgramIndicator")]
        public string FeeProgramIndicator { get; set; }
    }
}
