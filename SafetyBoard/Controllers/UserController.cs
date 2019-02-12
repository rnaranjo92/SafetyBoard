using SafetyBoard.Models;
using System.Data.Entity;
using SafetyBoard.Models.ViewModel;
using System;
using System.Collections.Generic;
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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }
        public ActionResult Index()
        {
            var users = _context.Users.Include(u => u.UserType).ToList();

            return View(users);
        }
        public ActionResult Details(int id)
        {
            var user = _context.Users.Include(u => u.UserType).SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }
        public ActionResult Edit(int id)
        {
            var user = _context.Users.Include(u => u.UserType).SingleOrDefault(u => u.Id == id);

            if(user.Id == 0)
                return HttpNotFound();
                var viewModel = new UserViewModel()
                {
                    User = user,
                    UserType = _context.UserTypes.ToList(),
                    PageTitle = "Edit User"
                };
            return View("UserForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserViewModel
                {
                    User = user,
                    UserType = _context.UserTypes.ToList(),
                    PageTitle = "Edit"
                };

                return View("UserForm", viewModel);
            }
            if (user.Id == 0)
            {
                user.DateRegistered = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            else
            {
                var userInDb = _context.Users.Single(c => c.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.Organization = user.Organization;
                userInDb.UserTypeId = user.UserTypeId;
                userInDb.IsSubscribeToNewsletter = user.IsSubscribeToNewsletter;
                userInDb.BirthDate = user.BirthDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "User"); 
        }

        public ActionResult UserForm()
        {
            var userTypes = _context.UserTypes.ToList();

            var viewModel = new UserViewModel()
            {
                User = new User(),
                UserType = userTypes,
                PageTitle = "New User"
            };
            return View(viewModel);
        }
    }
}