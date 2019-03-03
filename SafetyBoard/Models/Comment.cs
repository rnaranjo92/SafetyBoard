using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Posting Posting { get; set; }

        [Required]
        public int PostingId { get; set; }

        public string @comment { get; set; }

    }
}