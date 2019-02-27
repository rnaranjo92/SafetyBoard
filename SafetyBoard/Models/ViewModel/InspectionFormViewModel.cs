using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models.ViewModel
{
    public class InspectionFormViewModel
    {
        public ApplicationUser Inspector { get; set; }

        [Required]
        public string InspectorId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        public IEnumerable<Organization> Organization { get; set; }

        [Required]
        public int OrganizationId { get; set; }
        
        public IEnumerable<PostingType> InspectionType { get; set; }

        [Required]
        public byte InspectionTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        public string Title { get; set; }

        public DateTime DateTime
        {
            get { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
        }
    }

    
}