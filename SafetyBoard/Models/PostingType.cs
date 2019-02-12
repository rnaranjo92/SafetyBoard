using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models
{
    public class PostingType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string SafetyCategory { get; set; }
    }
}