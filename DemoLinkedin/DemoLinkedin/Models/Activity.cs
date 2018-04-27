using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLinkedin.Models
{
    [Serializable]
    public class Activity
    {
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "content")]
        public ActivityContent Content { get; set; }
    }

}