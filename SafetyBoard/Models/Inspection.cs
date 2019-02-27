using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Inspector { get; set; }

        public string InspectorId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public Organization Organization { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        public PostingType InspectionType { get; set; }

        public int InspectionTypeId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}