using AutoMapper;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafetyBoard.Controllers
{
    public class OrganizationController : Controller
    {
        private ApplicationDbContext _context;

        public OrganizationController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrganization(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new OrganizationFormViewModel
                {
                    Organization = organization,
                    PageTitle = "Edit"
                };
                return View(viewModel);
            }
            if(organization.Id == 0)
            {
                _context.Organizations.Add(organization);
            }
            else
            {
                var organizationInDb = _context.Organizations.SingleOrDefault(c => c.Id == organization.Id);
                organizationInDb.Name = organization.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Organization");

        }

        public ActionResult Edit(int id)
        {
            var organizationInDb = _context.Organizations.SingleOrDefault(c => c.Id == id);

            var viewModel = new OrganizationFormViewModel
            {
                Organization = organizationInDb,
                PageTitle = "Edit"
            };
            return View("OrganizationForm",viewModel);
        }
        public ActionResult OrganizationForm()
        {
            var viewModel = new OrganizationFormViewModel()
            {
                Organization = new Organization(),
                PageTitle = "New"
            };
            return View(viewModel);
        }
    }
}