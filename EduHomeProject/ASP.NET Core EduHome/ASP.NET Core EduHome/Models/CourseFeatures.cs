using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class CourseFeatures:BaseEntity
    {
        public string Starts { get; set; }
        public string Duration { get; set; }
        public string ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public int Students { get; set; }
        public string Assesment { get; set; }
        public int Price { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
