using System;

namespace SafetyBoard.Models.ViewModel
{
    public class CanceledInspectionViewModel
    {
        public DateTime DateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SafetyCategory { get; set; }
    }
}