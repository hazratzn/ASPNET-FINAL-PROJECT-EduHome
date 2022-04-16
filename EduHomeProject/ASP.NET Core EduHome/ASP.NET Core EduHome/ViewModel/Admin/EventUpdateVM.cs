using ASP.NET_Core_EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel.Admin
{
    public class EventUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public Event Event { get; set; }
        [Required]
        public List<Teacher> Teachers { get; set; }

        public List<EventSpeaker> EventSpeakers { get; set; }
        [Required]
        public IFormFile Photo { get; set; }

    }
}
