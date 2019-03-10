using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get;  private set; }

        public DateTime DateTime { get;   set; }

        
        public Organization Organization { get; set; }

        [Required]
        public int OrganizationId { get;   set; }

        
        public PostingType InspectionType { get; set; }

        [Required]
        public byte InspectionTypeId { get;  set; }

        [Required]
        public string Description { get;  set; }

        public bool IsCanceled { get; set; }

        public Inspection()
        {

        }

        public Inspection(string userId, DateTime dateTime, byte inspectionTypeId, int organizationId, string description)
        {
            if (userId == null)
                throw new ArgumentNullException("User Id is null");

            UserId = userId;
            DateTime = dateTime;
            InspectionTypeId = inspectionTypeId;
            OrganizationId = organizationId;
            Description = description;
        }
    }
}