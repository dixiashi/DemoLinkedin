using System.Runtime.Serialization;

namespace DemoLinkedin.Models
{
    [DataContract]
    public class SiteStandardProfileRequest
    {
        [DataMember(Name = "URL")]
        public string URL { get; set; }
    }
}