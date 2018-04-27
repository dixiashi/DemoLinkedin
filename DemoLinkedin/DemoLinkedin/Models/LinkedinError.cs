using System.Runtime.Serialization;

namespace DemoLinkedin.Models
{
    [DataContract]
    public class LinkedinError
    {
        [DataMember(Name = "error")]
        public string ErrorType { get; set; }

        [DataMember(Name = "error_description")]
        public string ErrorMessage { get; set; }
    }
}