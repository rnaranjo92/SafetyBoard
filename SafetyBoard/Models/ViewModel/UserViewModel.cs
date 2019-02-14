using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models.ViewModel
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string DriversLicense { get; set; }
        public string PhoneNumber { get; set; }
        public int MyProperty { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}