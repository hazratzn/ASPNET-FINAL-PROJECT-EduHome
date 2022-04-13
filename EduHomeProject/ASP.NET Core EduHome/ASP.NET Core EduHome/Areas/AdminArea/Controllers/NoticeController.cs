using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class NoticeController : Controller
    {

        private readonly AppDbContext _context;

        public NoticeController(AppDbContext context)
        {
            _context = context;


        }
        public async Task<IActionResult> Index()
        {
            List<Notice> notice = await _context.Notice.Where(m => m.IsDelete == false).OrderByDescending(m => m.Id).ToListAsync();
            return View(notice);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notice notice)
        {
            if (!ModelState.IsValid) return View();
            await _context.Notice.AddAsync(notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            Notice notice = await _context.Notice.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (notice == null) return NotFound();
            notice.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Update(int id)
        {
            Notice notice = await _context.Notice.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (notice == null) return NotFound();
            return View(notice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Notice notice)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("_", "Something went wrong");
            }
            if (id != notice.Id) return BadRequest();

            Notice dbnotice = await _context.Notice
                .Where(m => m.Id == notice.Id)
                .FirstOrDefaultAsync();

            dbnotice.NoticeBoard = notice.NoticeBoard;
            dbnotice.Date = notice.Date;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Notice notice = await _context.Notice.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(notice);
        }

    }
}
