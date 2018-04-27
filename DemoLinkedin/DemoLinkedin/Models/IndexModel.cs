using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLinkedin.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
            Profile = new Profile();
            Connections = new List<Connection>();
        }
        public Profile Profile { get; set; }
        public List<Connection> Connections { get; set; }
        public Contacts Contacts { get; set; }
    }
}