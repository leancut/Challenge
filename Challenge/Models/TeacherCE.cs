using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenge.Models
{
    public class TeacherCE
    {
        [Required]
        [Display(Name= "Teacher´s Name ")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Teacher´s Surename ")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Teacher´s ID ")]
        public int DNI { get; set; }
        [Display(Name = "Teacher´s Status")]

        public string Status { get; set; }
    }

    [MetadataType(typeof(TeacherCE))]
    public partial class Teacher
    {
        public string Full_Name { get {return Name + " " + Surname; } }
    }
    
}