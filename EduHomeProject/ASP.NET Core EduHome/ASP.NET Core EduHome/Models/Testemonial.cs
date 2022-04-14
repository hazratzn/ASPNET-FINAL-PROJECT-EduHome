using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Testemonial:BaseEntity
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
