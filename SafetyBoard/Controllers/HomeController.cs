﻿using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using SafetyBoard.Models.ViewModel;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
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
            var user = _context.Users.Include(u=>u.Organization).SingleOrDefault(u => u.Id == currentUser);
            var userProfilePic = _context.ProfileImages.OrderByDescending(pi => pi.Id).FirstOrDefault(pi => pi.UserId == user.Id);

            var upcomingInspections = _context.Inspections
                .Include(i => i.User)
                .Include(i=>i.InspectionType)
                .Include(i=>i.Organization)
                .Where(i => i.DateTime > DateTime.Now && i.OrganizationId == user.OrganizationId  && i.IsCanceled == false).ToList();

            var articles = _context.SafetyNews.Include(sn=>sn.User).Where(sn => sn.IsRemoved == false && sn.DatePosted.Month == DateTime.Now.Month && sn.DatePosted.Year == DateTime.Now.Year);

            var likes = _context.Like.Where(l => l.LikerId == currentUser).ToList().ToLookup(l => l.SafetyNewsId);

            var viewModel = new HomeViewModel(upcomingInspections, user,articles,likes,userProfilePic);

            return View("Index",viewModel);
        }
        public ActionResult PostArticle(SafetyNews safetyNews,HttpPostedFileBase imageFile) 
        {
            var currentUser = User.Identity.GetUserId();
            var article = new SafetyNews
            {
                UserId = currentUser,
                Title = safetyNews.Title,
                Article = safetyNews.Article,
                IsRemoved = false,
                DatePosted = DateTime.Now,
            };

            var poster = _context.Users.Single(u => u.Id == currentUser);
            var notification = Notification.NewSafetyNews(article);

            var users = _context.Users.Where(u => u.OrganizationId == poster.OrganizationId).ToList();

            foreach (var user in users)
            {
                user.Notify(notification);
            }

            _context.SafetyNews.Add(article);
            _context.SaveChanges();

            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            var newImage = new SafetyNewsImages
            {
                ImagePath = "~/Image/" + fileName,
                SafetyNewsId = article.Id
            };

            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);

            imageFile.SaveAs(fileName);

            _context.SafetyNewsImages.Add(newImage);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateArticle(ArticleViewModel viewModel)
        {
            var articleInDb = _context.SafetyNews.SingleOrDefault(s => s.Id == viewModel.Article.Id);

            articleInDb.Title = viewModel.Article.Title;
            articleInDb.Article = viewModel.Article.Article;


            _context.SaveChanges();

            return RedirectToAction("ViewArticle", "Home", new { id = viewModel.Article.Id });
        }

        public ActionResult ViewArticle(int id)
        {
            var article = _context.SafetyNews.Include(sn=>sn.User).Include(sn=>sn.User.Organization).SingleOrDefault(sn => sn.Id == id);

            var comments = _context.Comments
                .Include(c => c.User)
                .Include(c => c.User.Organization)
                .Where(c => c.SafetyNewsId == id).ToList();

            if(article == null)
            {
                throw new ArgumentNullException();
            }

            var viewModel = new ArticleViewModel
            {
                Article = article,
                User = article.User,
                Comments = comments,
                ProfileImage = _context.ProfileImages.OrderByDescending(pi => pi.Id).FirstOrDefault(pi => pi.UserId == article.UserId),
                Likers = _context.Like.Where(l => l.SafetyNewsId == article.Id && l.LikerId != article.UserId).Select(l => l.Liker).ToList(),
                safetyNewsImages = _context.SafetyNewsImages.Where(sni => sni.SafetyNewsId == id).ToList()
            };
            if (viewModel.Likers.Count()==0)
            {
                viewModel.IsLikeEmpty = true;
            }
            return View(viewModel);
        }

        public ActionResult DeleteArticle(int id)
        {
            var article = _context.SafetyNews.SingleOrDefault(sn => sn.Id == id);

            if (article == null)
            {
                throw new ArgumentNullException();
            }

            article.IsRemoved = true;

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddComment(Comment comment)
        {
            var newComment = new Comment
            {
                postComment = comment.postComment,
                SafetyNewsId = comment.SafetyNewsId,
                UserId = comment.UserId,
                DatePosted = DateTime.Now
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();
            return RedirectToAction("ViewArticle","Home",new { id = comment.SafetyNewsId});
        }
        public ActionResult EditComment(int id)
        {
            var currentUser = User.Identity.GetUserId();
            var comment = _context.Comments.Single(c => c.Id == id && c.UserId == currentUser);
            return View("EditComment",comment);
        }

        public ActionResult SaveComment(Comment newComment)
        {
            var oldComment = _context.Comments.Single(c => c.Id == newComment.Id);
            oldComment.postComment = newComment.postComment;
            _context.SaveChanges();
            return RedirectToAction("ViewArticle","Home", new { id = newComment.SafetyNewsId});
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