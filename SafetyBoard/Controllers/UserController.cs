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
    [Authorize(Roles = RoleName.CanManagePost)]
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
        
    }
}