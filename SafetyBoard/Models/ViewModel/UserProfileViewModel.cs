using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models.ViewModel
{
    public class UserProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<SafetyNews> SafetyNews { get; set; }
        public ProfileImage ProfileImage { get; set; }
    }
}