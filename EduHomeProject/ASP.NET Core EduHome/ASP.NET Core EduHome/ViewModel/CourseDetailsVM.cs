using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class CourseDetailsVM
    {
        public Course Course { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }
        public List<CourseFeatures> CourseFeatures { get; set; }
        public Advertisment Advertisment { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
