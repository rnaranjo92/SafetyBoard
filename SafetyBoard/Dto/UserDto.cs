using System.ComponentModel.DataAnnotations;

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

        public string PhoneNumber { get; set; }

        public bool AllowAccess { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserDto()
        {

        }
    }
}