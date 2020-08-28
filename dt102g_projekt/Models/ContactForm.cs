using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dt102g_projekt.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Namn ej angett.")]
        [Display(Name="Namn")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "E-post ej angedd.")]
        [Display(Name = "E-post")]
        [EmailAddress(ErrorMessage = "E-post adressen är ej giltig.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Meddelande ej angett.")]
        [Display(Name = "Meddelande")]
        public string Message { get; set; }
    }
}
