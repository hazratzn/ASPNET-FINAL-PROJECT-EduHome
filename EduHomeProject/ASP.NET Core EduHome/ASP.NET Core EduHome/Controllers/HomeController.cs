using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Slider.ToListAsync();
            List<ProfessionalTeacher> proteachers = await _context.ProTeacher.ToListAsync();
            Welcome welcome = await _context.Welcome.FirstOrDefaultAsync();
            List<Course> course = await _context.Course.ToListAsync();
            Video video = await _context.Video.FirstOrDefaultAsync();
            List<Notice> notice = await _context.Notice.ToListAsync();
            List<Event> events = await _context.Event.ToListAsync();
            Testemonial testemonials = await _context.Testemonial.FirstOrDefaultAsync();
            List<Blog> blog = await _context.Blog.ToListAsync();



            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                ProfessionalTeacher = proteachers,
                Welcome = welcome,
                Course = course,
                Video = video,
                Notice = notice,
                Event = events,
                Testemonial =testemonials,
                Blog = blog,



            };

            return View(homeVM);
        }


    }
}
