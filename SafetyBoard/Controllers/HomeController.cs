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
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(u => u.Id == currentUser);

            var upcomingInspections = _context.Inspections
                .Include(i => i.User)
                .Include(i=>i.InspectionType)
                .Include(i=>i.Organization)
                .Where(i => i.DateTime > DateTime.Now && i.OrganizationId == user.OrganizationId  && i.IsCanceled == false).ToList();

            var articles = _context.SafetyNews.Include(sn=>sn.User).Where(sn => sn.IsRemoved == false && sn.DatePosted.Month == DateTime.Now.Month && sn.DatePosted.Year == DateTime.Now.Year);

            var viewModel = new HomeViewModel(upcomingInspections, user,articles);

            return View("Index",viewModel);
        }

        public ActionResult PostArticle(HomeViewModel viewModel) 
        {
            var article = new SafetyNews()
            {
                UserId = User.Identity.GetUserId(),
                Title = viewModel.PostArticle.Title,
                Article = viewModel.PostArticle.Article,
                DatePosted = DateTime.Now,
            };
            _context.SafetyNews.Add(article);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}