using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Setting:BaseEntity
    {
        public string FooterLogo { get; set; }
        public string Text { get; set; }
        public string Adress { get; set; }
        public string PhoneNumFirst { get; set; }
        public string PhoneNumSecond { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string HeaderLogo { get; set; }
    }
}
