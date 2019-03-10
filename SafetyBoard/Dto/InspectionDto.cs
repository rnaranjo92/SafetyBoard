using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Dto
{
    public class InspectionDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DateTime { get; set; }
        public OrganizationDto Organization { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        public PostingTypeDto InspectionType { get; set; }
        public string Description { get; set; }
        public bool IsCanceled { get; set; }
    }
}