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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;


        public BlogController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blog.ToListAsync();

            BlogVM blogVM = new BlogVM
            {
                Blog =blogs,
            };
            return View(blogVM);
        }
        public async Task<IActionResult> BlogDetails( int id)
        {
            Blog blog = await _context.Blog
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            BlogDetailVM blogdetailVM = new BlogDetailVM
            {
                Blog = blog,
            };
            return View(blogdetailVM);
        }
    }
}
