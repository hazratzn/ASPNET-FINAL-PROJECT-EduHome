using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class LayoutVM
    {
        public Setting Setting { get; set; }
        public List<SocialNetwork>  SocialNetwork { get; set; }
    }
}
