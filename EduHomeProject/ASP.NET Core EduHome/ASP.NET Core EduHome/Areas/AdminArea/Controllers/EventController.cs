using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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


            List<EventSpeaker> eventSpeakers = await _context.EventSpeakers.Include(m => m.Teachers).ToListAsync();

            EventCreateVM eventCreateVM = new EventCreateVM()
            {
                EventSpeakers = eventSpeakers
            };
            return View(eventCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateVM eventCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (!eventCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (eventCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + eventCreateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await eventCreateVM.Photo.CopyToAsync(stream);
            }


            List<EventSpeaker> list = new List<EventSpeaker>();

            bool isChecked = eventCreateVM.EventSpeakers.Any(m => m.Teachers.IsChecked == true);

            if (isChecked == true)
            {
                list.AddRange(eventCreateVM.EventSpeakers.Where(m => m.Teachers.IsChecked));
            }



            Event @event = new Event()
            {
                Image = filename,
                Date = eventCreateVM.Event.Date,
                Name = eventCreateVM.Event.Name,
                Time = eventCreateVM.Event.Time,
                Location = eventCreateVM.Event.Location,
                Description = eventCreateVM.Event.Description,
                EventSpeakers = list
            };

            await _context.Event.AddAsync(@event);
            await _context.SaveChangesAsync();
            List<EventSpeaker> speakers = new List<EventSpeaker>();
            if (isChecked == true)
            {
                foreach (var speaker in @event.EventSpeakers)
                {
                    EventSpeaker eventSpeaker = new EventSpeaker()
                    {
                        EventId = @event.Id,
                        TeacherId = speaker.TeacherId
                    };
                    speakers.Add(eventSpeaker);
                }
            }
            await _context.EventSpeakers.AddRangeAsync(speakers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Event events = await _context.Event.Where(m => m.Id == id).FirstOrDefaultAsync();
           
            if (events == null) return NotFound();
            string path = Path.Combine(_enviroment.WebRootPath, "assets/img/event", events.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            events.IsDelete = true;
          
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
