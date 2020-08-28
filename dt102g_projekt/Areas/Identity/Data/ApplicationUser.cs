using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dt102g_projekt.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [PersonalData]
        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
    }
}
