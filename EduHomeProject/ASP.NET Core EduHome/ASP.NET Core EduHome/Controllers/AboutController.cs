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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;


        public AboutController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            Welcome welcome = await _context.Welcome.FirstOrDefaultAsync();
            List<Teacher> teachers = await _context.Teachers.ToListAsync();
            Video video = await _context.Video.FirstOrDefaultAsync();
            List<Notice> notice = await _context.Notice.ToListAsync();
            Testemonial testemonials = await _context.Testemonial.FirstOrDefaultAsync();






            AboutVM aboutVM = new AboutVM()
            {
               
                Welcome=welcome,
                Teachers =teachers,
                Video = video,
                Notice = notice,
                Testemonial = testemonials,


            };
            return View(aboutVM);
        }
    }
}
