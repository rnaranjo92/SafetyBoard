using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models.ViewModel
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Organization { get; set; }
    }
}