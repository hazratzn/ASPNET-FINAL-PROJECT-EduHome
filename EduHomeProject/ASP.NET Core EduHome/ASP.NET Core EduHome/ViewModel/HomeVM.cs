using ASP.NET_Core_EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<ProfessionalTeacher> ProfessionalTeacher { get; set; }
        public Welcome Welcome { get; set; }
        public List<Course> Course { get; set; }
        public Video Video { get; set; }
        public List<Notice> Notice { get; set; }
        public List<Event> Event { get; set; }
        public Testemonial Testemonial { get; set; }
        public List<Blog> Blog { get; set; }


    }
}
