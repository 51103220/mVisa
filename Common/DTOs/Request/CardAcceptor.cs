using System.Runtime.Serialization;

namespace Common.DTOs.Request
{
    [DataContract]
    public class CardAcceptor
    {
        [DataMember(Name ="idCode")]
        public string IdCode { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "address")]
        public Address Address { get; set; } = new Address();
              
    }
}
