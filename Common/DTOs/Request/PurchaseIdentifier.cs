using System.Runtime.Serialization;

namespace Common.DTOs.Request
{
    [DataContract]
    public class PurchaseIdentifier
    {
        [DataMember(Name ="type")]
        public string Type { get; set; }
        [DataMember(Name = "referenceNumber")]
        public string ReferenceNumber { get; set; }
              
    }
}
