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
            List<Course> courses = await _context.Course.Where(m => m.IsDelete == false).ToListAsync();




            CourseVM courseVM = new CourseVM
            {
               Courses=courses,



            };

            return View(courseVM);
        }
        public async Task<IActionResult> CourseDetails(int id)
        {
            Course course = await _context.Course.Where(m => m.IsDelete == false).Where(m=>m.Id==id).Include(m => m.CourseFeatures).FirstOrDefaultAsync();
            List<CourseCategory> courseCategories = await _context.CourseCategories.Where(m => m.IsDelete == false).ToListAsync();
            Advertisment advertisment = await _context.Advertisment.Where(m => m.IsDelete == false).FirstOrDefaultAsync();
            List<Blog> blog = await _context.Blog.Where(m => m.IsDelete == false).ToListAsync();
            List<Tag> tags = await _context.Tags.Where(m => m.IsDelete == false).ToListAsync();

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
        public async Task<IActionResult> Search(string course)
        {
            ViewData["GetCourses"] = course;

            if (!String.IsNullOrEmpty(course))
            {
                List<Course> courseQuery = await _context.Course.Where(m => m.Title.Trim().ToLower().Contains(course.Trim().ToLower())).ToListAsync();
                return View(courseQuery);
            }
            return View();
        }

    }
}
