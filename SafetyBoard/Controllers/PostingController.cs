using SafetyBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using SafetyBoard.Models.ViewModel;

namespace SafetyBoard.Controllers
{
    public class PostingController : Controller
    {
        private ApplicationDbContext _context;

        public PostingController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManagePost))
                return View("Index");
            return View("ReadOnlyIndex");
        }
        public ActionResult Details(int id)
        {
            var posting = _context.Postings.Include(p => p.PostingType).SingleOrDefault(p => p.Id == id);

            if (posting == null)
                return HttpNotFound();

            return View(posting);

        }
        public ActionResult PostingForm()
        {
            var postingTypes = _context.PostingTypes.ToList();
            var viewModel = new PostingFormViewModel()
            {
                Posting = new Posting(),
                PostingTypes = postingTypes,
                PageTitle = "New"
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(Posting posting)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PostingFormViewModel
                {
                    Posting = posting,
                    PostingTypes = _context.PostingTypes.ToList(),
                    PageTitle = "Edit"
                };
                return View("PostingForm",viewModel);
            }
            if (posting.Id == 0)
            {
                posting.TimePosted = DateTime.Now;
                _context.Postings.Add(posting);
            }
            else
            {
                var postingInDb = _context.Postings.Single(p => p.Id == posting.Id);
                postingInDb.Title = posting.Title;
                postingInDb.PostingTypeId = posting.PostingTypeId;
                postingInDb.TimePosted = posting.TimePosted;
                postingInDb.Description = posting.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Posting");
        }
        public ActionResult Edit(int id)
        {
            var posting = _context.Postings.SingleOrDefault(p => p.Id == id);

            if (posting == null)
                return HttpNotFound();
            var viewModel = new PostingFormViewModel()
            {
                Posting = posting,
                PostingTypes = _context.PostingTypes.ToList(),
                PageTitle = "Edit"
            };
            return View("PostingForm",viewModel);
        }
    }
}