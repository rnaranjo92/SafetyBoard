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

        public ActionResult MyProfile()
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.Include(u=>u.Organization).SingleOrDefault(u => u.Id == currentUser);

            var viewModel = new MyProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                OrganizationId = _context.Organizations.ToList().Where(o=>o.Id == user.OrganizationId),
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
                OrganizationId = _context.Organizations.ToList(),
                PhoneNumber = user.PhoneNumber,
                DriversLicense = user.DriversLicense
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostProfile(ApplicationUser appUser)
         {
            var currentUser = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                var currentUser1 = User.Identity.GetUserId();
                var user = _context.Users.Include(u => u.Organization).SingleOrDefault(u => u.Id == currentUser);

                var viewModel = new MyProfileViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    OrganizationId = _context.Organizations.ToList().Where(o => o.Id == user.OrganizationId),
                    PhoneNumber = user.PhoneNumber,
                    DriversLicense = user.DriversLicense
                };

                return View("Edit Profile",viewModel);
            }


            var userInDb = _context.Users.SingleOrDefault(u => u.Id == currentUser);
            userInDb.FirstName = appUser.FirstName;
            userInDb.LastName = appUser.LastName;
            userInDb.Email = appUser.Email;
            userInDb.OrganizationId = appUser.OrganizationId;
            userInDb.PhoneNumber = appUser.PhoneNumber;
            userInDb.DriversLicense = appUser.DriversLicense;


            _context.SaveChanges();
            return RedirectToAction("MyProfile");
        }
    }
}