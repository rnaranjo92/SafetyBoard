﻿using System.Collections.Generic;

namespace SafetyBoard.Models.ViewModel
{
    public class ArticleViewModel
    {
        public ApplicationUser User { get; set; }
        public SafetyNews Article { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public ProfileImage ProfileImage { get; set; }
        public IEnumerable<ApplicationUser> Likers { get; set; }
        public IEnumerable<SafetyNewsImages> safetyNewsImages { get; set; }
        public bool IsLikeEmpty { get; set; }
    }
}