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
using ASP.NET_Core_EduHome.ViewModel.Admin;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;

        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blog = await _context.Blog
                .Where(m => !m.IsDelete)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
           

            return View(blog);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blogCreateVM)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["From"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Title"].ValidationState == ModelValidationState.Invalid ||
                 ModelState["Date"].ValidationState == ModelValidationState.Invalid||
                  ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                   ModelState["Comment"].ValidationState == ModelValidationState.Invalid) return View();

            if (!blogCreateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is invalid");
                return View();
            }
            if (blogCreateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "_" + blogCreateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/blog", filename);
            string postPath = Helper.GetPath(_enviroment.WebRootPath, "assets/img/post", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blogCreateVM.Photo.CopyToAsync(stream);
            }
            
            Blog blog = new Blog()
            {
                Image = filename,
                Description = blogCreateVM.Description,
                Title = blogCreateVM.Title,
                Date = blogCreateVM.Date,
                Comment = blogCreateVM.Comment,
                From = blogCreateVM.From,
                PostImage = filename,
                
            };
            await _context.Blog.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = await _context.Blog.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();
            string path = Path.Combine(_enviroment.WebRootPath, "assets/img/blog", blog.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            blog.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _context.Blog.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BlogUpdateVM blogUpdateVM)
        {
            if (!blogUpdateVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File was not found");
            }
            if (blogUpdateVM.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid ||
                ModelState["From"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Title"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Date"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid || 
                ModelState["Comment"].ValidationState == ModelValidationState.Invalid) return View();
            if (id != blogUpdateVM.Id) return BadRequest();
            Blog dbblog = await _context.Blog.Where(m => m.Id == blogUpdateVM.Id).FirstOrDefaultAsync();
            string filname = Guid.NewGuid().ToString() + "_" + blogUpdateVM.Photo.FileName;
            string path = Helper.GetPath(_enviroment.WebRootPath, "assets/img/blog", filname);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blogUpdateVM.Photo.CopyToAsync(stream);
            }
            dbblog.Image = filname;
            dbblog.Description = blogUpdateVM.Description;
            dbblog.Title = blogUpdateVM.Title;
            dbblog.Comment = blogUpdateVM.Comment;
            dbblog.Date = blogUpdateVM.Date;
            dbblog.From = blogUpdateVM.From;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Blog blog = await _context.Blog.Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(blog);
        }
    }
}
