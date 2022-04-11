using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Testemonial:BaseEntity
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
    }
}
