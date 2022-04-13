using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
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
    public class WelcomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _enviroment;

        public WelcomeController(AppDbContext context , IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;


        }
        public async Task<IActionResult> Index()
        {
            Welcome welcome = await _context.Welcome.FirstOrDefaultAsync();
            return View(welcome);
        }
        public async Task<IActionResult> Update(int id)
        {
            Welcome welcome = await _context.Welcome.Where(m=>m.Id == id).FirstOrDefaultAsync();
            if(welcome == null) return NotFound();
            return View(welcome);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Welcome welcome)
        {
            if (!welcome.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (welcome.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Ttile"].ValidationState == ModelValidationState.Invalid) return View();
            if (id != welcome.Id) return BadRequest();
            Welcome dbwelcome = await _context.Welcome.Where(m => m.Id == welcome.Id).FirstOrDefaultAsync();
            string filename = Guid.NewGuid().ToString() + "_" + welcome.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/about", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await welcome.Photo.CopyToAsync(stream);
            }
            dbwelcome.Image = filename;
            dbwelcome.Description = welcome.Description;
            dbwelcome.Ttile = welcome.Ttile;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
