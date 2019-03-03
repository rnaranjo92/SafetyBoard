using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Posting
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="A Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        public PostingType PostingType { get; set; }

        [Required(ErrorMessage = "A Safety Category is required")]
        [Display(Name = "Safety Category")]
        public byte PostingTypeId { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime? TimePosted { get; set; }

        public Organization Organization { get; set; }

        public int OrganizationId { get; set; }
    }
}