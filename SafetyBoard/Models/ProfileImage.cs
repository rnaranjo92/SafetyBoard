using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models
{
    public class ProfileImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}