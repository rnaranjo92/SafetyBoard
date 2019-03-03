using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
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
            var usersWithRoles = (from user in _context.Users.Include(c=>c.Organization)
                                  select new
                                  {
                                      user.Id,
                                      user.Email,
                                      user.PhoneNumber,
                                      user.Organization,
                                      user.AllowAccess

                                  }).ToList().Select(p => new UserViewModel()

                                  {
                                      Id = p.Id,
                                      Email = p.Email,
                                      PhoneNumber = p.PhoneNumber,
                                      Organization = p.Organization.Name,
                                      AllowAccess = p.AllowAccess
                                  });


            return View(usersWithRoles);

        }

        public ActionResult MyProfile()
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.Include(u=>u.Organization).SingleOrDefault(u => u.Id == currentUser);

            var vieModel = new MyProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.Email,
                Organization = user.Organization,
                PhoneNumber = user.PhoneNumber
            };

            return View(vieModel);
        }

    }
}