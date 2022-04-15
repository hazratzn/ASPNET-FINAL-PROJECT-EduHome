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
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;


        }
        public async Task<IActionResult> Index()
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync();
            return View(contact);
        }
        public async Task<IActionResult> Update(int id)
        {
            Contact contact = await _context.Contacts.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (contact == null) return NotFound();
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id, Contact contact)
        {
            if (id != contact.Id) return BadRequest();

            Contact dbcontact= await _context.Contacts.Where(m => m.Id == contact.Id).FirstOrDefaultAsync();
            dbcontact.WebSite = contact.WebSite;
            dbcontact.PhoneNum = contact.PhoneNum;
            dbcontact.Location = contact.Location;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
