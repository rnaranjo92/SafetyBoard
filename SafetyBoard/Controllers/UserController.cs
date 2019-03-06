using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SafetyBoard.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult MyProfile(string id)
        {
            var user = _context.Users.Include(u=>u.Organization).SingleOrDefault(u => u.Id == id);

            var viewModel = new MyProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Organization = _context.Organizations.ToList(),
                OrganizationName = user.Organization.Name,
                PhoneNumber = user.PhoneNumber,
                DriversLicense = user.DriversLicense
            };

            return View(viewModel);
        }

        public ActionResult EditProfile()
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.Include(u => u.Organization).SingleOrDefault(u => u.Id == currentUser);

            if(user == null)
            {
                throw new ArgumentNullException();
            }

            var viewModel = new MyProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Organization = _context.Organizations.ToList(),
                OrganizationId = user.OrganizationId,
                PhoneNumber = user.PhoneNumber,
                DriversLicense = user.DriversLicense
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostProfile(MyProfileViewModel viewModel)
         {

            if (!ModelState.IsValid)
            {
                viewModel.Organization = _context.Organizations.ToList();
                return View("EditProfile",viewModel);
            }

            var currentUser = User.Identity.GetUserId();
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == currentUser);
            userInDb.FirstName = viewModel.FirstName;
            userInDb.LastName = viewModel.LastName;
            userInDb.Email = viewModel.Email;
            userInDb.OrganizationId = viewModel.OrganizationId;
            userInDb.PhoneNumber = viewModel.PhoneNumber;
            userInDb.DriversLicense = viewModel.DriversLicense;

            _context.SaveChanges();

            return RedirectToAction("MyProfile","User",new { id = User.Identity.GetUserId()});
        }
    }
}