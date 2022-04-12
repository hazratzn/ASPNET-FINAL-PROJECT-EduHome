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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;


        public CourseController(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Course.ToListAsync();




            CourseVM courseVM = new CourseVM
            {
               Courses=courses,



            };

            return View(courseVM);
        }
        public async Task<IActionResult> CourseDetails(int id)
        {
            Course course = await _context.Course.Where(m=>m.Id==id).Include(m => m.CourseFeatures).FirstOrDefaultAsync();
            List<CourseCategory> courseCategories = await _context.CourseCategories.ToListAsync();
            Advertisment advertisment = await _context.Advertisment.FirstOrDefaultAsync();
            List<Blog> blog = await _context.Blog.ToListAsync();
            List<Tag> tags = await _context.Tags.ToListAsync();

            CourseDetailsVM coursedetailsVM = new CourseDetailsVM
            {
                Course = course,
                CourseCategories = courseCategories,
                Advertisment = advertisment,
                Blogs=blog,
                Tags=tags,
            };

            return View(coursedetailsVM);
        }

    }
}
