using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.ViewModel.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeacherController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;

        }
        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _context.Teachers
                .Where(m => !m.IsDelete)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            return View(teachers);
        }
        public async Task< IActionResult> Create()
        {
            List<Skill> skills = await _context.Skills.ToListAsync();
            TeacherCreateVM teacherCreateVM = new TeacherCreateVM()
            {
                Skills = skills,
            };
            return View(teacherCreateVM);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateVM teacherCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (!teacherCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (teacherCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + teacherCreateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/teacher", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await teacherCreateVM.Photo.CopyToAsync(stream);
            }
            
            TeacherContact teacherContact = new TeacherContact()
            {
                Mail = teacherCreateVM.TeacherContacts.Mail,
                Skype = teacherCreateVM.TeacherContacts.Mail,
                Phone = teacherCreateVM.TeacherContacts.Phone,
                TeacherId = teacherCreateVM.Id
            };
            await _context.TeacherContacts.AddAsync(teacherContact);
            TeacherDetail teacherDetail = new TeacherDetail() 
            {
                Degree = teacherCreateVM.TeacherDetails.Degree,
                Experience = teacherCreateVM.TeacherDetails.Experience,
                Hobbies = teacherCreateVM.TeacherDetails.Hobbies,
                Faculty = teacherCreateVM.TeacherDetails.Faculty,
                TeacherId = teacherCreateVM.Id
                

            };
            await _context.TeacherDetails.AddAsync(teacherDetail);

            Teacher teacher = new Teacher()
            {
                Image = filename,
                FullNAME = teacherCreateVM.Teacher.FullNAME,
                Profession = teacherCreateVM.Teacher.Profession,
                About = teacherCreateVM.Teacher.About,
                TeacherDetails = teacherDetail,
                TeacherContacts = teacherContact
                

            };
            
            


            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            Teacher lastteacher = await _context.Teachers.OrderByDescending(m => m.Id).FirstOrDefaultAsync();

            int count = 0;
            foreach (var skills in teacherCreateVM.Skills)
            {
                TeacherSkill teacherSkill = new TeacherSkill()
                {
                    SkillId = skills.Id,
                    TeacherId = lastteacher.Id,
                    Percentage = teacherCreateVM.Percentage[count]
                };
                count++;
                await _context.TeacherSkills.AddAsync(teacherSkill);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}
