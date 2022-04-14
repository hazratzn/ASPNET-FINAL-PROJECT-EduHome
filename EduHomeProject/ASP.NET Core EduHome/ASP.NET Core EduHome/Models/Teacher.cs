﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Models
{
    public class Teacher:BaseEntity
    {
        public string Image { get; set; }
        public string Profession { get; set; }
        public string FullNAME { get; set; }
        public string About { get; set; }
        public TeacherDetail TeacherDetails { get; set; }
        public TeacherContact TeacherContacts { get; set; }
        public TeacherSkill TeacherSkills { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
