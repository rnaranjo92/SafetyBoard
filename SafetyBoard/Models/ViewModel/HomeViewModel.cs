using System.Collections.Generic;

namespace SafetyBoard.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Inspection> Inspection { get; set; }

        public ApplicationUser User { get; set; }

        public HomeViewModel()
        {

        }
        public HomeViewModel(IEnumerable<Inspection> inspection, ApplicationUser user)
        {
            Inspection = inspection;
            User = user;
        }
    }
}