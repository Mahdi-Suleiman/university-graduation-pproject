using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tutor.Models
{
    public class TutorCourses
    {
        [Key, Column(Order = 0)]
        public string TutorId { get; set; }

        [Key, Column(Order = 1)]

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ApplicationUser Tutor { get; set; }
    }
}