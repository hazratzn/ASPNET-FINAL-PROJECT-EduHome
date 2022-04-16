using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            List<Teacher> teachers = await _context.Teachers.Where(m => m.IsDelete == false).ToListAsync();


            EventCreateVM eventCreateVM = new EventCreateVM()
            {
                EventSpeakers = eventSpeakers,
                Teachers = teachers
            };
            return View(eventCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateVM eventCreateVM)
        {
            if (!ModelState.IsValid) return View(eventCreateVM);

            if (!eventCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View(eventCreateVM);
            }
            if (eventCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View(eventCreateVM);
            }

            string filename = Guid.NewGuid().ToString() + "_" + eventCreateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await eventCreateVM.Photo.CopyToAsync(stream);
            }


            List<Teacher> list = new List<Teacher>();

            bool isChecked = eventCreateVM.Teachers.Any(m => m.IsChecked == true);

            if (isChecked == true)
            {
                list.AddRange(eventCreateVM.Teachers.Where(m => m.IsChecked == true));
            }



            Event @event = new Event()
            {
                Image = filename,
                Date = eventCreateVM.Event.Date,
                Name = eventCreateVM.Event.Name,
                Time = eventCreateVM.Event.Time,
                Location = eventCreateVM.Event.Location,
                Description = eventCreateVM.Event.Description,
            };
            await _context.Event.AddAsync(@event);
            await _context.SaveChangesAsync();

            foreach (var item in list)
            {
                EventSpeaker eventSpeaker = new EventSpeaker
                {
                    EventId = @event.Id,
                    TeacherId = item.Id
                };
                await _context.EventSpeakers.AddAsync(eventSpeaker);
            }


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
        public async Task<IActionResult> Update(int id)
        {
            Event @event = await _context.Event.Where(m => m.Id == id).Include(m => m.EventSpeakers).ThenInclude(m => m.Teachers).FirstOrDefaultAsync();
            List<EventSpeaker> eventSpeakers = await _context.EventSpeakers.Where(m => m.EventId == id).Include(m => m.Teachers).ToListAsync();
            List<Teacher> teachers = await _context.Teachers.Where(m => m.IsDelete == false).ToListAsync();
            if (@event == null) return NotFound();
            if (@event.Id != id) return BadRequest();
            EventUpdateVM eventUpdateVM = new EventUpdateVM()
            {
                Event = @event,
                EventSpeakers = eventSpeakers,
                Teachers = teachers
            };
            return View(eventUpdateVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, EventUpdateVM eventUpdateVM)
        {
            if (!eventUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (eventUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (!ModelState.IsValid) return View();
            if (id != eventUpdateVM.Id) return BadRequest();
            Event dbevent = await _context.Event.Where(m => m.Id == eventUpdateVM.Id).FirstOrDefaultAsync();
            string filname = Guid.NewGuid().ToString() + "_" + eventUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/event", filname);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await eventUpdateVM.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_enviroment.WebRootPath, "assets/img/event", dbevent.Image);
            if (System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbevent.Image = filname;
            dbevent.Date = eventUpdateVM.Event.Date;
            dbevent.Description = eventUpdateVM.Event.Description;
            dbevent.Location = eventUpdateVM.Event.Location;
            dbevent.Time = eventUpdateVM.Event.Time;
            dbevent.Name = eventUpdateVM.Event.Name;
            dbevent.EventSpeakers = eventUpdateVM.EventSpeakers;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


    }
}
