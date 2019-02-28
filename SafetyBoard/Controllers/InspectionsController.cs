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
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schedule(InspectionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Organization = _context.Organizations.ToList();
                viewModel.InspectionType = _context.PostingTypes.ToList();
                return View("InspectionForm",viewModel);
            }
            var inspection = new Inspection
            {
                InspectorId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
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