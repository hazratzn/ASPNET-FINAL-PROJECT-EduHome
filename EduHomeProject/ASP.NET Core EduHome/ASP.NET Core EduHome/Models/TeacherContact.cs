using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class TeacherContact:BaseEntity
    {
        public string  Mail { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
