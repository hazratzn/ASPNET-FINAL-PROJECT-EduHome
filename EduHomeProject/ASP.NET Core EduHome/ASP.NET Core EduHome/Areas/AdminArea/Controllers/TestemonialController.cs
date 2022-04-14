using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;
using System.IO;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TestemonialController : Controller
    {

        private readonly IWebHostEnvironment _enviroment;
        private readonly AppDbContext _context;

        public TestemonialController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;


        }
        public async Task<IActionResult> Index()
        {
            List<Testemonial> testemonial = await _context.Testemonial.Where(m => m.IsDelete == false).OrderByDescending(m => m.Id).ToListAsync();
            if (testemonial == null) return NotFound();
            return View(testemonial);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testemonial testemonial)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Name"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Profession"].ValidationState == ModelValidationState.Invalid) return View();

            if (!testemonial.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (testemonial.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + testemonial.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/testimonial", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await testemonial.Photo.CopyToAsync(stream);
            }

            testemonial.Image = filename;
           
            await _context.Testemonial.AddAsync(testemonial);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Testemonial testemonial = await _context.Testemonial.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (testemonial == null) return NotFound();
            string path = Path.Combine(_enviroment.WebRootPath, "assets/img/testimonial", testemonial.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            testemonial.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            Testemonial testemonial = await _context.Testemonial.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (testemonial == null) return NotFound();
            return View(testemonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Testemonial testemonial)
        {
            if (!testemonial.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (testemonial.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Name"].ValidationState == ModelValidationState.Invalid || 
                ModelState["Profession"].ValidationState == ModelValidationState.Invalid) return View();
            if (id != testemonial.Id) return BadRequest();
            Testemonial dbtestemonial = await _context.Testemonial.Where(m => m.Id == testemonial.Id).FirstOrDefaultAsync();
            string filname = Guid.NewGuid().ToString() + "_" + testemonial.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/testimonial", filname);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await testemonial.Photo.CopyToAsync(stream);
            }
            dbtestemonial.Image = filname;
            dbtestemonial.Description = testemonial.Description;
            dbtestemonial.Name = testemonial.Name;
            dbtestemonial.Profession = testemonial.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Testemonial testemonial = await _context.Testemonial.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(testemonial);
        }
    }
}
