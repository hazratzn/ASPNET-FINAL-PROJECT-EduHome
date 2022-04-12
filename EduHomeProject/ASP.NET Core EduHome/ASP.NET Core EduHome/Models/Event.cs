using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Event:BaseEntity
    {
        public string Image { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }

    }
}
