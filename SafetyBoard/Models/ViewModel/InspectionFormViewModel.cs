﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models.ViewModel
{
    public class InspectionFormViewModel
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

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

        public string SafetyCategory { get; set; }

        [Required]
        public string Description { get; set; }

        public String Action
        {

            get
            {
                return (Id != 0) ? "Update" : "Schedule";
            }
        }

        public DateTime GetDateTime() 
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
        public string PageTitle { get; set; }
    }

    
}