using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Course:BaseEntity
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string  Apply { get; set; }
        [Required]
        public string  About { get; set; }
        [Required]
        public string Certificatiom { get; set; }
        [Required]
        public CourseCategory CourseCategory { get; set; }
        
        [Required]
        public CourseFeatures CourseFeatures { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
