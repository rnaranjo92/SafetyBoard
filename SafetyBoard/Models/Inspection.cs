using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        
        public ApplicationUser Inspector { get; set; }

        [Required]
        public string InspectorId { get; set; }

        public DateTime DateTime { get; set; }

        
        public Organization Organization { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        
        public PostingType InspectionType { get; set; }

        [Required]
        public byte InspectionTypeId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}