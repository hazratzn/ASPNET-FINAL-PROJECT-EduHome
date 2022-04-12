using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class EventDetailVM
    {
        public Event Event { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
