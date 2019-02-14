using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models.ViewModel
{
    public class UserViewModel
    {
        public List<UserType> UserType { get; set; }
        public User User { get; set; }
        public string PageTitle { get; set; }
    }
}