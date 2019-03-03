using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
            var posting = _context.Postings.Include(p => p.PostingType).Include(p=>p.User).Include(p=>p.User.Organization).SingleOrDefault(p => p.Id == id);

            var currentUser = User.Identity.GetUserId();

            var user = _context.Users.Single(u => u.Id == currentUser);

            var commentor = _context.Comments.Where(c => c.PostingId == posting.Id).ToList();

            var viewModel = new PostingDetailsViewModel
            {
                FirstName = posting.User.FirstName,
                LastName = posting.User.LastName,
                Email = posting.User.Email,
                PhoneNumber = posting.User.PhoneNumber,
                Description = posting.Description,
                Organization = posting.User.Organization.Name,
                SafetyCategory = posting.PostingType.SafetyCategory,
                TimePosted = posting.TimePosted,
                Comment = commentor,
                PostId = posting.Id,
                CurrentUser = user
            };

            if (posting == null)
                return HttpNotFound();

            return View(viewModel);

        }
        public ActionResult PostingForm()
        {
            var postingTypes = _context.PostingTypes.ToList();
            var viewModel = new PostingFormViewModel()
            {
                Posting = new Posting() { UserId = User.Identity.GetUserId()},
                PostingTypes = postingTypes,
                PageTitle = "New",
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
                var currentUser = User.Identity.GetUserId();
                var user = _context.Users.Single(u => u.Id == currentUser);
                posting.UserId = currentUser;
                posting.TimePosted = DateTime.Now;
                posting.OrganizationId = user.OrganizationId;
                _context.Postings.Add(posting);
            }
            else
            {
                var postingInDb = _context.Postings.Single(p => p.Id == posting.Id);
                postingInDb.Title = posting.Title;
                postingInDb.PostingTypeId = posting.PostingTypeId;
                postingInDb.TimePosted = posting.TimePosted;
                postingInDb.Description = posting.Description;
                postingInDb.UserId = posting.UserId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Posting");
        }
        [Authorize(Roles = RoleName.CanManagePost)]
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