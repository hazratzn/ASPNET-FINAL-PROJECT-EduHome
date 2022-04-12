using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;


        public EventController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _context.Event.ToListAsync();

            EventVM eventVM = new EventVM
            {
                Events = events,
            };

            return View(eventVM);
        }
        public async Task<IActionResult> EventDetails(int id)
        {
            Event events = await _context.Event
                
                .Where(m => m.Id == id)
                .Include(m => m.EventSpeakers)
                .ThenInclude(m => m.Teachers)
                .FirstOrDefaultAsync();

                EventDetailVM eventdetailsVM = new EventDetailVM()
                {
                    Event = events,
                };

            return View(eventdetailsVM);
        }
    }
}
