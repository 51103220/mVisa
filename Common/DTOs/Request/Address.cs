
using System.Runtime.Serialization;

namespace Common.DTOs.Request
{
    [DataContract]
    public class Address
    {
        [DataMember(Name ="city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }
    }
}
