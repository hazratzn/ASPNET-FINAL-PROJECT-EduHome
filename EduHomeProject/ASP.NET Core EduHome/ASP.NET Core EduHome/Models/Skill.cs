using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Skill:BaseEntity
    {
        public string Name { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
