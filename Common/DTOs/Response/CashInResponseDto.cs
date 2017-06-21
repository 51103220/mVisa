using Common.DTOs.Response.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Response
{
    [DataContract]
    public class CashInResponseDto : BaseResponseDto
    {
        [DataMember(Name = "transactionDateTime")]
        public string TransactionDateTime { get; set; }

        [DataMember(Name = "transmissionDateTime")]
        public string TransmissionDateTime { get; set; }

    }
}
