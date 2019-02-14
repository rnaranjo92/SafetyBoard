using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafetyBoard.Controllers
{
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
            var userRoles = new List<UserViewModel>();
            var userStore = new UserStore<ApplicationUser>(_context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            foreach (var user in userStore.Users)
            {
                var r = new UserViewModel
                {
                    Email = user.Email,
                    DriversLicense = user.DriversLicense,
                    PhoneNumber = user.PhoneNumber
                };
                userRoles.Add(r);
            }
            //Get all the Roles for our users
            foreach (var user in userRoles)
            {
                user.Roles = userManager.GetRoles(userStore.Users.First(s => s.Email == user.Email).Id);
            }

            return View(userRoles);
        }
    }
}