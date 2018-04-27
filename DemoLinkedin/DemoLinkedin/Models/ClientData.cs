using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DemoLinkedin.Models
{
    public class ClientData
    {
        public HttpMethod Method { get; set; }

        public string Accept { get { return "application/json"; } }

        public Dictionary<string, string> PostData { get; set; }

        public string BaseURL { get; set; }

        public string RelativeURL { get; set; }

        public string AccessToken { get; set; }

        public string JsonPostData { get; set; }
    }
}