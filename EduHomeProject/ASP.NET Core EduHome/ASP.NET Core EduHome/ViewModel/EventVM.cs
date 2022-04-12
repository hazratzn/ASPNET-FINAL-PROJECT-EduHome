using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class EventVM
    {
        public List<Event> Events { get; set; }
        public Advertisment Advertisment { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
