using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Dto
{
    public class UserDto
    {

        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        public OrganizationDto Organization { get; set; }

        [Required]
        public string DriversLicense { get; set; }
    }
}