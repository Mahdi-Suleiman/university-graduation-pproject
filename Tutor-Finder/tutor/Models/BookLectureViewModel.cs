using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutor.Models
{
    public class BookLectureViewModel
    {
        public DateTime StartTime { get; set; }
        public int CourseId { get; set; }
        public int Duration { get; set; }

        public virtual Course Course { get; set; }
    }
}