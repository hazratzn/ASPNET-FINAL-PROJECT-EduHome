using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Welcome:BaseEntity
    {
        public string Ttile { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
