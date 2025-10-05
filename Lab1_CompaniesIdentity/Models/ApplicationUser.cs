using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lab1_CompaniesIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Optional Phone (don’t mark as Required)
        [Display(Name = "Phone Number")]
        public override string? PhoneNumber { get; set; }

        // Optional City
        [StringLength(50)]
        [Display(Name = "City")]
        public string? City { get; set; }
    }
}
