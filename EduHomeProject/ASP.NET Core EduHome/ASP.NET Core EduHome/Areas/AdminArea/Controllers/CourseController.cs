using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CourseController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;

        }
        public async Task <IActionResult> Index()
        {
            List<Course> courses = await _context.Course
                .Where(m => m.IsDelete == false)
                .Include(m=>m.CourseCategory)
                .Include(m=>m.CourseFeatures)
                
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            CourseListVM courselistVM = new CourseListVM
            {
                Courses = courses,
            };
            return View(courselistVM);
        }
        public IActionResult Create()
        {
            // ViewBag.category = await GetCategories(); //
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateVM coursecreateVM)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Apply"].ValidationState == ModelValidationState.Invalid ||
                ModelState["About"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Certificatiom"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Starts"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Duration"].ValidationState == ModelValidationState.Invalid ||
                ModelState["ClassDuration"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Students"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Price"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Language"].ValidationState == ModelValidationState.Invalid ||
                 ModelState["Assesment"].ValidationState == ModelValidationState.Invalid) return View();

            if (!coursecreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (coursecreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            string filename = Guid.NewGuid().ToString() + "_" + coursecreateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/course", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await coursecreateVM.Photo.CopyToAsync(stream);
            }

            Course course = new Course()
            {
                Image = filename,
                Title = coursecreateVM.Title,
                Description = coursecreateVM.Description,
                Apply = coursecreateVM.Apply,
                About = coursecreateVM.About,
                Certificatiom = coursecreateVM.Certificatiom,


            };
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();

            CourseFeatures courseFeatures = new CourseFeatures()
            {
                Starts = coursecreateVM.Starts,
                Duration = coursecreateVM.Duration,
                ClassDuration = coursecreateVM.ClassDuration,
                SkillLevel = coursecreateVM.SkillLevel,
                Language = coursecreateVM.Language,
                Students = coursecreateVM.Students,
                Assesment = coursecreateVM.Assesment,
                Price = coursecreateVM.Price,
                CourseId = course.Id
            };
            await _context.TeacCourseFeatures.AddAsync(courseFeatures);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Course course = await _context.Course.Where(m => m.Id == id).FirstOrDefaultAsync();
            CourseFeatures courseFeatures = await _context.TeacCourseFeatures.Where(m => m.CourseId == course.Id).FirstOrDefaultAsync();
            if (course == null) return NotFound();
            string path = Path.Combine(_enviroment.WebRootPath, "assets/img/course", course.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            course.IsDelete = true;
            courseFeatures.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {
            Course course = await _context.Course.Where(m => m.Id == id).Include(m=>m.CourseFeatures).FirstOrDefaultAsync();
            if (course == null) return NotFound();
           

            CourseUpdateVM courseUpdateVM = new CourseUpdateVM()
            {
                About = course.About,
                Apply = course.Apply,
                Image = course.Image,
                Title = course.Title,
                Certificatiom = course.Certificatiom,
                Starts = course.CourseFeatures.Starts,
                Duration = course.CourseFeatures.Duration,
                ClassDuration = course.CourseFeatures.ClassDuration,
                Description =course.Description,
                SkillLevel = course.CourseFeatures.SkillLevel,
                Language = course.CourseFeatures.Language,
                Assesment = course.CourseFeatures.Assesment,
                Price = course.CourseFeatures.Price,
                Students = course.CourseFeatures.Students,
            };
            return View(courseUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CourseUpdateVM courseUpdateVM)
        {
            if (!courseUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (courseUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Apply"].ValidationState == ModelValidationState.Invalid ||
                ModelState["About"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Certificatiom"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Starts"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Duration"].ValidationState == ModelValidationState.Invalid ||
                ModelState["ClassDuration"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Students"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Price"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Language"].ValidationState == ModelValidationState.Invalid ||
                 ModelState["Assesment"].ValidationState == ModelValidationState.Invalid) return View();
            if (id != courseUpdateVM.Id) return BadRequest();
            Course dbcourse = await _context.Course.Where(m => m.Id == courseUpdateVM.Id).FirstOrDefaultAsync();
            string filname = Guid.NewGuid().ToString() + "_" + courseUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/slider", filname);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await courseUpdateVM.Photo.CopyToAsync(stream);
            }
            dbcourse.Image = filname;
            dbcourse.Description = courseUpdateVM.Description;
            dbcourse.Title = courseUpdateVM.Title;
            dbcourse.Certificatiom = courseUpdateVM.Description;
            dbcourse.Apply = courseUpdateVM.Apply;
            dbcourse.About = courseUpdateVM.About;
            dbcourse.CourseFeatures.Assesment = courseUpdateVM.Assesment;
            dbcourse.CourseFeatures.ClassDuration = courseUpdateVM.ClassDuration;
            dbcourse.CourseFeatures.Duration = courseUpdateVM.Duration;
            dbcourse.CourseFeatures.Language = courseUpdateVM.Language;
            dbcourse.CourseFeatures.SkillLevel = courseUpdateVM.SkillLevel;
            dbcourse.CourseFeatures.Students = courseUpdateVM.Students;
            dbcourse.CourseFeatures.Price = courseUpdateVM.Price;
            dbcourse.CourseFeatures.Starts = courseUpdateVM.Starts;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Course course = await _context.Course.Where(m => m.Id == id).Include(m => m.CourseFeatures).FirstOrDefaultAsync();

          
            if (course == null) return NotFound();

            return View(course);

        }


        
        
            
        
    }
}
