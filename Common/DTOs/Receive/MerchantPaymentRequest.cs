using Common.DTOs.Receive.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Receive
{
    [DataContract]
    public class MerchantPaymentRequest : BaseRequest
    {
        [DataMember(Name = "encMerchantPAN")]
        public string EncMerchantPAN { get; set; }

        [DataMember(Name = "transactionFeeAmount")]
        public string TransactionFeeAmount { get; set; }

        [DataMember(Name = "billIdFormat")]
        public string BillIdFormat { get; set; }

        [DataMember(Name = "billId")]
        public string BillId { get; set; }

        [DataMember(Name = "refId")]
        public string RefId { get; set; }

        [DataMember(Name =   "encConsumerPAN")]
        public string EncConsumerPAN { get; set; }

        [DataMember(Name = "encConsumerName")]
        public string EncConsumerName { get; set; }
    }
}
