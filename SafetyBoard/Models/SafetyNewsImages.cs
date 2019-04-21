using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models
{
    public class SafetyNewsImages
    {
        public int Id { get; set; }
        public SafetyNews SafetyNews { get; set; }
        public int SafetyNewsId { get; set; }
        public string ImagePath { get; set; }
    }
}