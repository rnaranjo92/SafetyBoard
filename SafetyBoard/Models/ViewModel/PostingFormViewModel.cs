using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models.ViewModel
{
    public class PostingFormViewModel
    {
        public IEnumerable<PostingType> PostingTypes { get; set; }
        public Posting Posting { get; set; }
        public string PageTitle { get; set; }
    }
}