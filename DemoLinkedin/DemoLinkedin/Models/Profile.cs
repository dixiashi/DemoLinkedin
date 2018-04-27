using System.Runtime.Serialization;

namespace DemoLinkedin.Models
{
    [DataContract]
    public class Profile
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "headline")]
        public string HeadLine { get; set; }

        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "siteStandardProfileRequest")]
        public SiteStandardProfileRequest SiteStandardProfileRequest { get; set; }


        [DataMember(Name = "numConnections")]
        public int NumConnections { get; set; }

        [DataMember(Name = "picture-url")]
        public string PictureUrl { get; set; }
    }
}