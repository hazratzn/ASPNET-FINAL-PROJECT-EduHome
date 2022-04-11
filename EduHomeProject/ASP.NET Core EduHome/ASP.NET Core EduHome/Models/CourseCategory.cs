using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class CourseCategory:BaseEntity
    {
        public  string Name { get; set; }
        public int Count { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
