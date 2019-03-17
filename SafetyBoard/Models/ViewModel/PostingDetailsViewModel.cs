using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SafetyBoard.Models.ViewModel
{
    public class PostingDetailsViewModel
    {
        public int PostId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Organization { get; set; }
        public string Description { get; set; }
        public string SafetyCategory { get; set; }
        public DateTime? TimePosted { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ApplicationUser CurrentUser { get; set; }

        public PostingDetailsViewModel()
        {
            Comment = new Collection<Comment>();
        }
    }
}