using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProTeacherController : Controller
    {
       
       
        private readonly AppDbContext _context;

        public ProTeacherController(AppDbContext context)
        {
            _context = context;
           

        }
        public async Task<IActionResult> Index()
        {
            List<ProfessionalTeacher> proTeacher =await _context.ProTeacher.Where(m=>m.IsDelete == false).OrderByDescending(m => m.Id).ToListAsync();
            return View(proTeacher);
        }
        public  IActionResult Create ()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionalTeacher proTeacher)
        {
            if (!ModelState.IsValid) return View();
            await _context.ProTeacher.AddAsync(proTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete (int id)
        {
            ProfessionalTeacher proTeacher = await _context.ProTeacher.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (proTeacher == null) return NotFound();
            proTeacher.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            ProfessionalTeacher proTeacher = await _context.ProTeacher.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (proTeacher == null) return NotFound();
            return View(proTeacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProfessionalTeacher proTeacher)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("_", "Something went wrong");
            }
            if (id != proTeacher.Id) return BadRequest();

            ProfessionalTeacher dbProTeacher = await _context.ProTeacher
                .Where(m => m.Id == proTeacher.Id)
                .FirstOrDefaultAsync();

            dbProTeacher.Title = proTeacher.Title;
            dbProTeacher.Description = proTeacher.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            ProfessionalTeacher proTeacher = await _context.ProTeacher.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(proTeacher);
        }
        
    }
}
