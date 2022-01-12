using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutor.Models
{
    public class Course
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name="Course")]
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> Tutors { get; set; }
    }
}