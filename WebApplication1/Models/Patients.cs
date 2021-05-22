using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class Patients
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Full name")]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter disease")]
        [Display(Name = "Disease")]
        public string Disease { get; set; }

        [Required(ErrorMessage = "Enter phone")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter treatment card number")]
        [Display(Name = "Treatment card number")]
        public string cardNumber { get; set; }
    }
}
