﻿using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System;
using System.Data.Entity;
using System.IO;
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
            var userProfilePic = _context.ProfileImages.OrderByDescending(pi => pi.Id).FirstOrDefault(pi => pi.UserId == user.Id);

            var viewModel = new MyProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Organization = _context.Organizations.ToList(),
                OrganizationName = user.Organization.Name,
                PhoneNumber = user.PhoneNumber,
                DriversLicense = user.DriversLicense,
                Image = userProfilePic
            };

            return View(viewModel);
        }

        public ActionResult ViewUserProfile(string id)
        {
            var user = _context.Users.Include(u=>u.Organization).Single(u => u.Id == id);
            var safetyNews = _context.SafetyNews.Where(sn => sn.UserId == id).ToList();
            var userProfilePic = _context.ProfileImages.OrderByDescending(pi => pi.Id).FirstOrDefault(pi => pi.UserId == user.Id);


            var viewModel = new UserProfileViewModel
            {
                User = user,
                SafetyNews = safetyNews,
                ProfileImage = userProfilePic
            };

            return View("UserProfile", viewModel);
        }

        public ActionResult EditProfile()
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.Include(u => u.Organization).SingleOrDefault(u => u.Id == currentUser);
            var userProfilePic = _context.ProfileImages.OrderByDescending(pi=>pi.Id).FirstOrDefault(pi => pi.UserId == user.Id);

            if (user == null)
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
                OrganizationName = user.Organization.Name,
                PhoneNumber = user.PhoneNumber,
                DriversLicense = user.DriversLicense,
                ImagePath = _context.ProfileImages.OrderByDescending(pi => pi.Id).FirstOrDefault(pi => pi.UserId == user.Id).Path,
                Image = userProfilePic
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

            if (!String.IsNullOrEmpty(viewModel.ImageFile.FileName))
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFile.FileName);
                string extension = Path.GetExtension(viewModel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                var newImage = new ProfileImage
                {
                    Path = "~/Image/" + fileName,
                    UserId = User.Identity.GetUserId()
                };

                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);

                viewModel.ImageFile.SaveAs(fileName);

                _context.ProfileImages.Add(newImage);
                _context.SaveChanges();
            }
            //How I saved file to image folder


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