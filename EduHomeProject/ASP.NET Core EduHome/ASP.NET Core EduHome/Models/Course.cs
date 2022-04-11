using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Course:BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string  Apply { get; set; }
        public string  About { get; set; }
        public string Certificatiom { get; set; }
        public CourseCategory CourseCategory { get; set; }
        public CourseFeatures CourseFeatures { get; set; }

    }
}
