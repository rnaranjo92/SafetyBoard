using System;

namespace SafetyBoard.Models
{
    public class SafetyNews
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DatePosted { get; set; }
        public string UserId { get; set; }
        public string Topic { get; set; }
        public string ContentBody { get; set; }
    }
}