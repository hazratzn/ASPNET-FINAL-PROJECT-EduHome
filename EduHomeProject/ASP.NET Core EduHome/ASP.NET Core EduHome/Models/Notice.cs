using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Notice:BaseEntity
    {
        public string Date { get; set; }
        public string NoticeBoard { get; set; }
        public string Size { get; set; }

    }
}
