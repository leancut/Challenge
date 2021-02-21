using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge.Models
{
    public class SubjectCE
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Subject´s Name ")]
        public string Name_Subject { get; set; }
        [Required]
        [Display(Name = "Subject´s Teacher ")]
        public int DNI_Teacher { get; set; }
        [Required]
        [Display(Name = "Subject´s Schedule Start ")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> Schedule_From { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Subject´s Schedule End ")]
        public Nullable<System.TimeSpan> Schedule_To { get; set; }
        [Required]
        [Display(Name = "Subject´s Quota")]
        public string Quota { get; set; }

        
    }
    [MetadataType(typeof(SubjectCE))]
    public partial class Subject
    {

    }
}