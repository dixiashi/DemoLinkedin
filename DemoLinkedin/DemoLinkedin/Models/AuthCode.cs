using System.Runtime.Serialization;

namespace DemoLinkedin.Models
{
    [DataContract]
    public class AuthCode
    {
        //[DataMember(Name = "access_token")]
        //public string AccessToken { get; set; }

        //[DataMember(Name = "expires_in")]
        //public string ExpiresIn { get; set; }

        public string access_token { get; set; }

        public string expires_in { get; set; }
    }
}