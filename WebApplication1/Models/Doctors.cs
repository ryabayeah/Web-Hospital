using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Full name")]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter speciallity")]
        [Display(Name = "Speciallity")]
        public string Speciallity { get; set; }




    }
}
