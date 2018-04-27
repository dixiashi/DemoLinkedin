using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLinkedin.Models
{
    [Serializable]
    public class Contacts
    {
        [JsonProperty(PropertyName = "_total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "values")]
        public List<Contacter> Contacters { get; set; }
    }
}