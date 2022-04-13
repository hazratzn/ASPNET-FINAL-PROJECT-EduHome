using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Controllers
{
    public class DashboardController : Controller
    {
        [Area("AdminArea")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
