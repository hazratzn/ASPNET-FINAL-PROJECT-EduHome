using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel.Admin
{
    public class BlogUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Title { get; set; }

        public string PostImage { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public IFormFile Photo { get; set; }
    }
}
