using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLinkedin.Models
{
    [Serializable]
    public class ActivityContent
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "submitted-url")]
        public string SubmittedUrl { get; set; }
        [JsonProperty(PropertyName = "submitted-image-url")]
        public string SubmittedImageUrl { get; set; }
    }

}