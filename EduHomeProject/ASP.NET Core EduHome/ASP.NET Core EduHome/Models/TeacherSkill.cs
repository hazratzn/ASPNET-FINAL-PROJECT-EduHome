using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class TeacherSkill:BaseEntity
    {
        public int Language { get; set; }
        public int TeamLeader { get; set; }
        public int Devolopment { get; set; }
        public int Design { get; set; }
        public int Innovation { get; set; }
        public int Communicatiom { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
