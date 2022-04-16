using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers;
using ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Pagination;
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
        public async Task<IActionResult> Index(int page = 1, int take = 10)
        {
            List<Teacher> teachers = await _context.Teachers
                .Where(m => !m.IsDelete)
                .Skip((page-1)*take)
                .Take(take)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            
            int count = await GetPageCount(take);
            Paginate<Teacher> pagination = new Paginate<Teacher>(teachers, page, count);
            return View(pagination);

        }
        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Teachers.CountAsync();
            return (int)Math.Ceiling((decimal)count / take);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Teacher teacher = await _context.Teachers.Where(m => m.Id == id).FirstOrDefaultAsync();
            TeacherContact teacherContact = await _context.TeacherContacts.Where(m => m.Id == id).FirstOrDefaultAsync();
            TeacherDetail teacherDetail = await _context.TeacherDetails.Where(m => m.Id == id).FirstOrDefaultAsync();
            TeacherSkill teacherSkill = await _context.TeacherSkills.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (teacher == null) return NotFound();
            string path = Path.Combine(_enviroment.WebRootPath, "assets/img/teacher", teacher.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            teacherDetail.IsDelete = true;
            teacherContact.IsDelete = true;
            teacherSkill.IsDelete = true;
            teacher.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            Teacher teacher = await _context.Teachers
                .Where(m => m.Id == id)
                .Include(m=>m.TeacherContacts)
                .Include(m => m.TeacherDetails)
                .Include(m=>m.TeacherSkills)
                .ThenInclude(m=>m.Skills)
                .FirstOrDefaultAsync();
            TeacherSkill teacherSkill = await _context.TeacherSkills.Where(m => m.TeacherId == teacher.Id).FirstOrDefaultAsync();
            List<Skill> skills = await _context.Skills.ToListAsync();
            if (teacher == null) return NotFound();

            TeacherUpdateVM teacherUpdateVM = new TeacherUpdateVM()
            {
                Teacher =teacher,
                TeacherContacts = teacher.TeacherContacts,
                TeacherDetails = teacher.TeacherDetails,
                Percentage = teacherSkill.Percentage,
                Skills =skills,
            };

            return View(teacherUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TeacherUpdateVM teacherUpdateVM)
        {
            if (!teacherUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (teacherUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (!ModelState.IsValid) return View();
            
            if (id != teacherUpdateVM.Id) return BadRequest();

            Teacher dbteacher = await _context.Teachers.Where(m => m.Id == teacherUpdateVM.Id)
                
                .Include(m => m.TeacherContacts)
                .Include(m => m.TeacherDetails)
                .Include(m => m.TeacherSkills)
                .ThenInclude(m => m.Skills)
                .FirstOrDefaultAsync();
            string filname = Guid.NewGuid().ToString() + "_" + teacherUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/teacher", filname);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await teacherUpdateVM.Photo.CopyToAsync(stream);
            }
            string lastImage = Path.Combine(_enviroment.WebRootPath, "assets/img/teacher", dbteacher.Image);
            if(System.IO.File.Exists(lastImage))
            {
                System.IO.File.Delete(lastImage);
            }
            dbteacher.Image = filname;
            dbteacher.Profession = teacherUpdateVM.Teacher.Profession;
            dbteacher.FullNAME = teacherUpdateVM.Teacher.FullNAME;
            dbteacher.About = teacherUpdateVM.Teacher.About;
            dbteacher.TeacherContacts.Mail = teacherUpdateVM.TeacherContacts.Mail;
            dbteacher.TeacherContacts.Phone = teacherUpdateVM.TeacherContacts.Phone;
            dbteacher.TeacherContacts.Skype = teacherUpdateVM.TeacherContacts.Skype;
            dbteacher.TeacherDetails.Degree = teacherUpdateVM.TeacherDetails.Degree;
            dbteacher.TeacherDetails.Experience = teacherUpdateVM.TeacherDetails.Experience;
            dbteacher.TeacherDetails.Hobbies = teacherUpdateVM.TeacherDetails.Hobbies;
            dbteacher.TeacherDetails.Faculty = teacherUpdateVM.TeacherDetails.Faculty;
            foreach (var teacherSkill in dbteacher.TeacherSkills)
            {
                teacherSkill.Percentage = teacherUpdateVM.Percentage;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Teacher teacher = await _context.Teachers.Where(m => m.Id == id)
                .Include(m => m.TeacherContacts)
                .Include(m => m.TeacherDetails)
                .Include(m => m.TeacherSkills)
                .ThenInclude(m => m.Skills)
                .FirstOrDefaultAsync();
            return View(teacher);
        }
    }
}
