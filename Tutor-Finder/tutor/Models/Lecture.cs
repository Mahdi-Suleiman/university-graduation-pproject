using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutor.Models
{
    public class Lecture
    {
        public int Id { get; set; }

        [Display(Name = "Tutor")]
        public string TutorId { get; set; }

        [Display(Name = "Student")]
        public string StudentId { get; set; }

        [Required]
        [Display(Name ="Time")]
        public DateTime StartTime { get; set; }

        [Required]
        public int Duration { get; set; }

        public double Price { get; set; }

        [Required]
        [Display(Name = "Study Place")]
        public int StudyPlaceId { get; set; }

        [Required]
        [Display(Name ="Course")]
        public int CourseId { get; set; }

        public bool Confirmed { get; set; }
        public virtual Course Course { get; set; }

        public virtual StudyPlace StudyPlace { get; set; }
        public virtual ApplicationUser Student { get; set; }
        public virtual ApplicationUser Tutor { get; set; }


    }
}