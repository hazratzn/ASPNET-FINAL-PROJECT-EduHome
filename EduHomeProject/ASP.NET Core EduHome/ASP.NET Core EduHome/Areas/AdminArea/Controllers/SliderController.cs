using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;

        }
        public async Task<IActionResult>  Index()
        {
            List<Slider> sliders = await _context.Slider
                .Where(m => !m.IsDelete)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (SliderVM sliderVM)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Title"].ValidationState == ModelValidationState.Invalid) return View();

            if (!sliderVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if(sliderVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + sliderVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/slider", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await sliderVM.Photo.CopyToAsync(stream);
            }
            string desc = sliderVM.Description;
            string title = sliderVM.Title;
            Slider slider = new Slider()
            {
                Image = filename,
                Description =desc,
                Title =title,
            };
            await _context.Slider.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Slider.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            string path = Path.Combine(_enviroment.WebRootPath, "assets/img/slider", slider.Image);
            if (System.IO.File.Exists(path)) 
            {
                System.IO.File.Delete(path);
            };
            slider.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            Slider slider = await _context.Slider.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Slider slider)
        {
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if(slider.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Title"].ValidationState == ModelValidationState.Invalid) return View();
            if (id != slider.Id) return BadRequest();
            Slider dbslider = await _context.Slider.Where(m => m.Id == slider.Id).FirstOrDefaultAsync();
            string filname = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/slider", filname);
            using(FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }
            dbslider.Image = filname;
            dbslider.Description = slider.Description;
            dbslider.Title = slider.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Slider.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(slider);
        }
    }
}
