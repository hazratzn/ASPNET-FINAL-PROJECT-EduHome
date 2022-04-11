using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class ProfessionalTeacher:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
