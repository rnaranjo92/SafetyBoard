using System.Collections.Generic;

namespace SafetyBoard.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Inspection> Inspection { get; set; }

        public ApplicationUser User { get; set; }

        public SafetyNews PostArticle { get; set; }

        public IEnumerable<SafetyNews> SafetyNews { get; set; }

        public HomeViewModel()
        {

        }
        public HomeViewModel(IEnumerable<Inspection> inspection, ApplicationUser user, IEnumerable<SafetyNews> safetyNews)  
        {
            Inspection = inspection;
            User = user;
            SafetyNews = safetyNews;
        }
        
    }
}