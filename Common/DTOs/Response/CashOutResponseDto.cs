using Common.DTOs.Request;
using Common.DTOs.Response.Base;
using System.Runtime.Serialization;

namespace Common.DTOs.Response
{
    [DataContract]
    public class CashOutResponseDto : BaseResponseDto
    {
        [DataMember(Name = "localTransactionDateTime")]
        public string LocalTransactionDateTime { get; set; }

        [DataMember(Name = "cardAcceptor")]
        public CardAcceptor CardAcceptor { get; set; } = new CardAcceptor();
    }
}
