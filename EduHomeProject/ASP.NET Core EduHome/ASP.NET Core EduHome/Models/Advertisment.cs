using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Advertisment:BaseEntity
    {
        public string Image { get; set; }
        public string Text { get; set; }
    }
}
