using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class TeacherSkill:BaseEntity
    {
        public int SkillId { get; set; }
        public Skill Skills { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Percentage { get; set; }
    }
}
