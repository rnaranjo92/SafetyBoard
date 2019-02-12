using SafetyBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }

        [Required(ErrorMessage = "Type of User is required")]
        public byte UserTypeId { get; set; }

        public UserTypeDto UserType { get; set; }

        //[Min18YearsOld]
        public DateTime? BirthDate { get; set; }

        public DateTime DateRegistered { get; set; }

        [Required(ErrorMessage = "Organization is required")]
        public string Organization { get; set; }
    }
}