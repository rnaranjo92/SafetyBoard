using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models
{
    public class Organization
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Organization Name")]
        public string Name { get; set; }
    }
}