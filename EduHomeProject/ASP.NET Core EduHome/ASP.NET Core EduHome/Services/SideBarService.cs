using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Services
{
    public class SideBarService
    {
        private readonly AppDbContext _context;

        public SideBarService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Advertisment> GetAdvertisment()
        {
            Advertisment advertisment = await _context.Advertisment.FirstOrDefaultAsync();

            return advertisment;
                
        }
        public async Task<List<Tag>> GetTags()
        {
            List<Tag> tags = await _context.Tags.ToListAsync();

            return tags;

        }
        public async Task<List<Blog>> GetBlogs()
        {
            List<Blog> blog = await _context.Blog.ToListAsync();

            return blog;

        }
        public async Task<List<CourseCategory>> CourseCategoriesAsync()
        {
            List<CourseCategory> courseCategories = await _context.CourseCategories.ToListAsync();

            return courseCategories;

        }

    }
}
