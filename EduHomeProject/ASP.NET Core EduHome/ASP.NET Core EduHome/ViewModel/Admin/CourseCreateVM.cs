using ASP.NET_Core_EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.ViewModel.Admin
{
    public class CourseCreateVM
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Apply { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Certificatiom { get; set; }
        [Required]
        public int CategoryId { get; set; }
       
        [Required]
        public string Starts { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string ClassDuration { get; set; }
        [Required]
        public string SkillLevel { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int Students { get; set; }
        [Required]
        public string Assesment { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
       
        public IFormFile Photo { get; set; }
       
       
    }
}
