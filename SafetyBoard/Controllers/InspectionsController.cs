using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace SafetyBoard.Controllers
{
    public class InspectionsController : Controller
    {
        private ApplicationDbContext _context;

        public InspectionsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult InspectionForm()
        {
            var organizations = _context.Organizations.ToList();
            var postingTypes = _context.PostingTypes.ToList();

            var viewModel = new InspectionFormViewModel
            {
                Organization = organizations,
                InspectionType = postingTypes,
                Title = "Schedule Inspection"
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Schedule(InspectionFormViewModel viewModel)
        {
            var inspection = new Inspection
            {
                InspectorId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                InspectionTypeId = viewModel.InspectionTypeId,
                OrganizationId = viewModel.OrganizationId,
                Description = viewModel.Description,
            };

            _context.Inspections.Add(inspection);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}