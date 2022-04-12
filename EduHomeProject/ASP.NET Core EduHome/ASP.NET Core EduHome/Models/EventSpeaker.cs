using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class EventSpeaker:BaseEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Events { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }

    }
}
