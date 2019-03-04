using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models.ViewModel
{
    public class MyProfileViewModel
    {
        [Required(ErrorMessage ="First Name is Required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Organization")]
        public IEnumerable<Organization> OrganizationId { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="License #")]
        public string DriversLicense { get; set; }
    }
}