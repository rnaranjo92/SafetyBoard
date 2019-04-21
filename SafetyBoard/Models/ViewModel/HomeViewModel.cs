using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Inspection> Inspection { get; private set; }

        public ApplicationUser User { get; private set; }

        public SafetyNews SafetyNews { get; private set; }

        public IEnumerable<SafetyNews> ListOfSafetyNews { get; private set; }

        public ILookup<int,Like> Like { get; set; }

        public Comment Comment { get; set; }

        public ProfileImage ProfileImage { get; set; }

        public SafetyNewsImages SafetyNewsImages { get; set; }

        public IEnumerable<SafetyNewsImages> ListOfSafetyNewsImages { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


        public HomeViewModel()
        {

        }
        public HomeViewModel(IEnumerable<Inspection> inspection, ApplicationUser user, IEnumerable<SafetyNews> safetyNews, ILookup<int,Like> like,ProfileImage profileImage)  
        {
            Inspection = inspection;
            User = user;
            ListOfSafetyNews = safetyNews;
            Like = like;
            ProfileImage = profileImage;
        }
        
    }
}