using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class AboutVM
    {
        public Welcome Welcome { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Video Video { get; set; }
        public List<Notice> Notice { get; set; }
        public Testemonial Testemonial { get; set; }
    }
}
