using ASP.NET_Core_EduHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<ProfessionalTeacher> ProTeacher { get; set; }
        public DbSet<Welcome> Welcome { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Testemonial> Testemonial { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<SocialNetwork> SoicalNetworks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<TeacherContact> TeacherContacts { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<CourseFeatures> TeacCourseFeatures { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Advertisment> Advertisment { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Contact> Contacts { get; set; }





    }
}
