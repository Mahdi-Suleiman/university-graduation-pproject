using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutor.Models
{
    public class StudyPlace
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name="Study Place")]
        public string Name { get; set; }

        [Display(Name ="Phone Number")]
        [StringLength(13)]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string Location { get; set; }

        public string Image { get; set; }
    }
}