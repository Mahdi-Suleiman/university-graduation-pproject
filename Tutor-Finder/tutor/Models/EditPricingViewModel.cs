using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutor.Models
{ 
    public class EditPricingViewModel
    {
        [Required]
        [Display(Name = "One Hour Price")]
        [Range(1, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double OneHourPrice { get; set; }

        [Required]
        [Display(Name = "Two Hour Price")]
        [Range(1, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double TwoHourPrice { get; set; }

        [Required]
        [Display(Name = "Three Hour Price")]
        [Range(1, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double ThreeHourPrice { get; set; }
    }
}