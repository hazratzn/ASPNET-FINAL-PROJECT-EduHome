using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class SideBarVM
    {
        public List<Tag> Tags { get; set; }
        public List<Blog> Blogs { get; set; }
        public Advertisment Advertisments { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }

    }
}
