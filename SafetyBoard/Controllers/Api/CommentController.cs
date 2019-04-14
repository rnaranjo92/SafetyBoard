using AutoMapper;
using Microsoft.AspNet.Identity;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace SafetyBoard.Controllers.Api
{
    public class CommentController : ApiController
    {
        private ApplicationDbContext _context;

        public CommentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            var currentUser = User.Identity.GetUserId();
            var comment = _context.Comments.Single(c => c.Id == id && c.UserId == currentUser);
            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return Ok();
        }
    }
}
