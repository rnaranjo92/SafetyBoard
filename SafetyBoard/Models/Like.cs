using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyBoard.Models
{
    public class Like
    {
        public SafetyNews SafetyNews { get; set; }

        public ApplicationUser Liker { get; set; }

        [Key]
        [Column(Order =1)]
        public int SafetyNewsId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string LikerId { get; set; }
    }
}