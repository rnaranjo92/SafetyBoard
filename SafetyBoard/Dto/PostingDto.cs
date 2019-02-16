using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Dto
{
    public class PostingDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public byte PostingTypeId { get; set; }

        public PostingTypeDto PostingType { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }

        [Required]
        public string UserId { get; set; }

        public UserDto User { get; set; }

    }
}