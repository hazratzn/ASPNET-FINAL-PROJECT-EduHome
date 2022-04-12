using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class TeacherDetailsVM
    {
        public Teacher Teacher { get; set; }
        public List<Skill> Skills { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
        
    }
}
