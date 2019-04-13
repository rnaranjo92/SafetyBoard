using System;

namespace SafetyBoard.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public SafetyNews SafetyNews { get; set; }

        public int SafetyNewsId { get; set; }

        public string postComment { get; set; }

        public DateTime DatePosted { get; set; }

        public Comment()
        {

        }
    }
}