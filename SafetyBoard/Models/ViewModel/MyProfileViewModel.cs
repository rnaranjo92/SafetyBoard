using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models.ViewModel
{
    public class MyProfileViewModel
    {
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Organization Organization { get; set; }

        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}