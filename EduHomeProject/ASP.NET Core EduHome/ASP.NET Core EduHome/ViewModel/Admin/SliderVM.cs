using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel.Admin
{
    public class SliderVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public IFormFile Photo { get; set; }
    }
}
