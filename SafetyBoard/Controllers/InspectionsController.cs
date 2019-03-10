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

            var viewModel = new InspectionFormViewModel(organizations, postingTypes, PageTitles.Schedule);
            
            return View(viewModel);
        }

        [Authorize]
        public ActionResult View(int id)
        {
            var currentUser = User.Identity.GetUserId();
            var inspections = _context.Inspections.Include(c=>c.User).Include(c => c.InspectionType).Single(i => i.Id == id);

            var viewModel = new InspectionFormViewModel(
                inspections.DateTime.ToString("d MMM yyyy"), 
                inspections.DateTime.ToString("HH:mm"), 
                inspections.Description, 
                inspections.InspectionTypeId, 
                inspections.InspectionType.SafetyCategory,
                inspections.User, 
                inspections.OrganizationId);
            
            return View("View",viewModel);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var organizations = _context.Organizations.ToList();
            var postingTypes = _context.PostingTypes.ToList();
            var user = User.Identity.GetUserId();
            var inspections = _context.Inspections.Include(i => i.User).Include(i => i.InspectionType).Single(i => i.Id == id && i.UserId == user);


            var viewModel = new InspectionFormViewModel(postingTypes, inspections.InspectionType.SafetyCategory, organizations, inspections.Id, inspections.DateTime.ToString("d MMM yyyy"), inspections.DateTime.ToString("HH:mm"), inspections.Description, inspections.InspectionTypeId, inspections.UserId, inspections.OrganizationId, PageTitles.Edit);
            
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
            var inspection = _context.Inspections.Single(i => i.Id == viewModel.Id && i.User.Id == userId);
            inspection.OrganizationId = viewModel.OrganizationId;
            inspection.InspectionTypeId = viewModel.InspectionTypeId;
            inspection.DateTime = viewModel.GetDateTime();
            inspection.Description = viewModel.Description;

            _context.SaveChanges();

            var notification = Notification.InspectionUpdated(inspection);

            var users = _context.Users.Where(u => u.OrganizationId == inspection.OrganizationId).ToList();

            foreach (var user in users)
            {
                user.Notify(notification);
            }

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
            var inspection = new Inspection(User.Identity.GetUserId(), viewModel.GetDateTime(), viewModel.InspectionTypeId, viewModel.OrganizationId, viewModel.Description);
            

            _context.Inspections.Add(inspection);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}