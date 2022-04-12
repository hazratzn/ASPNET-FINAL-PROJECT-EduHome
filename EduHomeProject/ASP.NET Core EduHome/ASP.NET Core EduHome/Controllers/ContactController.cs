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

            ContactVM contactVM = new ContactVM
            {
                Contact =contact,
            };
            return View(contactVM);
        }
    }
}
