using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }

        public UserType UserType { get; set; }

        [Required(ErrorMessage = "Type of User is required")]
        [Display(Name = "Type of User")]
        public byte UserTypeId { get; set; }

        
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Date Registered")]
        public DateTime DateRegistered { get; set; }

        [Required(ErrorMessage = "Organization is required")]
        public string Organization { get; set; }
    }
}