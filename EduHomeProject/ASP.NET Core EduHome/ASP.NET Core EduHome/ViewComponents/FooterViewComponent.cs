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
    public class FooterViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;
        
        public FooterViewComponent(LayoutService layoutService, AppDbContext context)
        {
            _layoutService = layoutService;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Setting settings = await _layoutService.GetSettings();
            List<SocialNetwork> socialnetworks = await _layoutService.GetSocial();
            LayoutVM layoutVM = new LayoutVM()
            {
                Setting = settings,
                SocialNetwork = socialnetworks,
            };
            return (await Task.FromResult(View(layoutVM)));
        }
    }
}
