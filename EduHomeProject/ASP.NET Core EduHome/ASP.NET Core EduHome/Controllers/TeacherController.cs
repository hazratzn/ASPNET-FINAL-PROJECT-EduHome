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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;


        public TeacherController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Teacher> teacher = await _context.Teachers.ToListAsync();

            TeacherVM teacherVM = new TeacherVM()
            {
                Teachers =teacher,
            };
            return View(teacherVM);
        }
        public async Task<IActionResult> TeacherDetails(int id)
        {
            Teacher teacher = await _context.Teachers
                .Where(m=>m.Id == id)
                .Include(m=>m.TeacherContacts)
                .Include(m=>m.TeacherDetails)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .FirstOrDefaultAsync();
          


            TeacherDetailsVM teacherdetailsVM = new TeacherDetailsVM()
            {
                Teacher = teacher,
            };
            return View(teacherdetailsVM);
        }
    }
}
