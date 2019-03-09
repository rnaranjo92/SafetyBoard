using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime DateTime { get; set; }

        
        public Organization Organization { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        
        public PostingType InspectionType { get; set; }

        [Required]
        public byte InspectionTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCanceled { get; set; }

    }
}