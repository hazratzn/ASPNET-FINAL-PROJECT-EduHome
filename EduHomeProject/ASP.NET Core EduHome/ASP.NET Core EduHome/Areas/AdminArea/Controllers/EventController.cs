using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EventController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly AppDbContext _context;

        public EventController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;

        }
        public async Task< IActionResult> Index()
        {
            List<Event> events = await _context.Event.Where(m => m.IsDelete == false).OrderByDescending(m => m.Id).ToListAsync();
            return View(events);
        
        }
        public async Task<IActionResult> Create()
        {

            
            List<EventSpeaker> eventSpeakers = await _context.EventSpeakers
               
                .Include(m=>m.Teachers)
                .ToListAsync();

            EventCreateVM eventCreateVM = new EventCreateVM()
            {
               
                EventSpeakers =eventSpeakers,
            };
            return View(eventCreateVM);
        }
    }
}
