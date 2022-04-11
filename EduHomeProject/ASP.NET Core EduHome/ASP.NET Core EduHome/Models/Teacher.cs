using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Teacher:BaseEntity
    {
        public string Image { get; set; }
        public string Profession { get; set; }
        public string FullNAME { get; set; }
        public string About { get; set; }
        public List<TeacherDetail> TeacherDetails { get; set; }
        public List<TeacherContact> TeacherContacts { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
