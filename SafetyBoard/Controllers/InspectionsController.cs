using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System.Data.Entity;
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
                PageTitle = "Schedule an Inspection",
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult View(int id)
        {
            var currentUser = User.Identity.GetUserId();
            var inspections = _context.Inspections.Include(c=>c.Inspector).Include(c => c.InspectionType).Single(i => i.Id == id);

            var viewModel = new InspectionFormViewModel
            {
                Date = inspections.DateTime.ToString("d MMM yyyy"),
                Time = inspections.DateTime.ToString("HH:mm"),
                Description = inspections.Description,
                InspectionTypeId = inspections.InspectionTypeId,
                SafetyCategory = inspections.InspectionType.SafetyCategory,
                Inspector = inspections.Inspector,
                OrganizationId = inspections.OrganizationId,
            };
            return View("View",viewModel);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var organizations = _context.Organizations.ToList();
            var postingTypes = _context.PostingTypes.ToList();
            var user = User.Identity.GetUserId();
            var inspections = _context.Inspections.Include(i => i.Inspector).Include(i => i.InspectionType).Single(i => i.Id == id && i.InspectorId == user);


            var viewModel = new InspectionFormViewModel
            {
                InspectionType = postingTypes,
                SafetyCategory = inspections.InspectionType.SafetyCategory,
                Organization = organizations,

                Id = inspections.Id,
                Date = inspections.DateTime.ToString("d MMM yyyy"),
                Time = inspections.DateTime.ToString("HH:mm"),
                Description = inspections.Description,
                InspectionTypeId = inspections.InspectionTypeId,
                InspectorId = inspections.InspectorId,
                OrganizationId = inspections.OrganizationId,
                PageTitle = "Edit"
            };
            return View("InspectionForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(InspectionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Organization = _context.Organizations.ToList();
                viewModel.InspectionType = _context.PostingTypes.ToList();
                return View("InspectionForm", viewModel);
            }
            var userId = User.Identity.GetUserId();
            var inspection = _context.Inspections.Single(i => i.Id == viewModel.Id && i.Inspector.Id == userId);
            inspection.OrganizationId = viewModel.OrganizationId;
            inspection.InspectionTypeId = viewModel.InspectionTypeId;
            inspection.DateTime = viewModel.GetDateTime();
            inspection.Description = viewModel.Description;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
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