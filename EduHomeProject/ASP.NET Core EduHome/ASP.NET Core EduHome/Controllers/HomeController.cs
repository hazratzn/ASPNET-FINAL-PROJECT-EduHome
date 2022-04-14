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
            List<Slider> sliders = await _context.Slider.Where(m => m.IsDelete == false).ToListAsync();
            List<ProfessionalTeacher> proteachers = await _context.ProTeacher.Where(m => m.IsDelete == false).ToListAsync();
            Welcome welcome = await _context.Welcome.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Course> course = await _context.Course.Where(m => m.IsDelete == false).ToListAsync();
            Video video = await _context.Video.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Notice> notice = await _context.Notice.Where(m => m.IsDelete == false).ToListAsync();
            List<Event> events = await _context.Event.Where(m => m.IsDelete == false).ToListAsync();
            Testemonial testemonials = await _context.Testemonial.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Blog> blog = await _context.Blog.Where(m => m.IsDelete == false).ToListAsync();



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
