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
    public class TeacherCreateVM
    {
        public int Id { get; set; }
        [Required]
        public List<int> Percentage { get; set; }
        [Required]
        public List<Skill> Skills { get; set; }
        [Required]
        public Teacher Teacher { get; set; }
        
        [Required]
        public TeacherDetail TeacherDetails { get; set; }
        [Required]
        public TeacherContact TeacherContacts { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
