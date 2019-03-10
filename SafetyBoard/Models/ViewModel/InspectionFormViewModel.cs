using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models.ViewModel
{
    public class InspectionFormViewModel
    {
        public int Id { get;   set; }

        public ApplicationUser User { get;   set; }

        public string UserId { get;  set; }

        [Required]
        public string Date { get;   set; }

        [Required]
        public string Time { get;  set; }

        public IEnumerable<Organization> Organization { get;   set; }

        [Required]
        public int OrganizationId { get;  set; }
        
        public IEnumerable<PostingType> InspectionType { get;  set; }

        [Required]
        public byte InspectionTypeId { get;   set; }

        public string SafetyCategory { get;   set; }

        [Required]
        public string Description { get;   set; }

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

        public string PageTitle { get;  set; }

        public InspectionFormViewModel()
        {

        }

        public InspectionFormViewModel(IEnumerable<Organization> organizations, IEnumerable<PostingType> postingTypes,string pageTitle)
        {
            Organization = organizations;
            InspectionType = postingTypes;
            PageTitle = pageTitle;
        }

        public InspectionFormViewModel(string date, string time, string description, byte inspectionTypeId, string safetyCategory, ApplicationUser user, int organizationId)
        {
            if (user == null)
                throw new ArgumentNullException();

            Date = date;
            Time = time;
            Description = description;
            InspectionTypeId = inspectionTypeId;
            SafetyCategory = safetyCategory;
            User = user;
            OrganizationId = organizationId;
        }

        public InspectionFormViewModel(IEnumerable<PostingType> postingTypes, string safetyCategory, IEnumerable<Organization> organizations, int inspectionId, string time, string date, string description, byte inspectionTypeId, string userId, int organizationId,  string pageTitle)
        {
            InspectionType = postingTypes;
            SafetyCategory = safetyCategory;
            Organization = organizations;
            Id = inspectionId;
            Time = time;
            Date = date;
            Description = description;
            InspectionTypeId = inspectionTypeId;
            UserId = userId;
            OrganizationId = organizationId;
            PageTitle = pageTitle;
        }

    }

    public class PageTitles
    {
        public const string Schedule = "Schedule an Inspection";
        public const string Edit = "Edit an Inspection";

    }
}