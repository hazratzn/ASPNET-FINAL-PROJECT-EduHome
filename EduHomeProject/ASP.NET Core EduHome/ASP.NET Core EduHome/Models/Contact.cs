using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Contact:BaseEntity
    {
        public string Location { get; set; }
        public string PhoneNum { get; set; }
        public string WebSite { get; set; }
       
    }
}
