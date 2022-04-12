using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using ASP.NET_Core_EduHome.Services;
using ASP.NET_Core_EduHome.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {
        private readonly SideBarService _sidebarService;

        public SideBarViewComponent(SideBarService sidebar)
        {
            _sidebarService = sidebar;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Tag> tag = await _sidebarService.GetTags();
            List<Blog> blogs = await _sidebarService.GetBlogs();
            Advertisment advertisment = await _sidebarService.GetAdvertisment();
            List<CourseCategory> coursecategories = await _sidebarService.CourseCategoriesAsync();

            SideBarVM sidebarVM = new SideBarVM()
            {
                Tags = tag,
                Blogs = blogs,
                Advertisments = advertisment,
                CourseCategories = coursecategories,
                
                
            };


            return (await Task.FromResult(View(sidebarVM)));
        }
    }
}
