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
        [HttpPost]
        public IHttpActionResult Comment(PostingDto postingDto)
        {
            var posting = _context.Postings.Single(p => p.Id == postingDto.Id);

            var currentUser = User.Identity.GetUserId();

            var postComment = new CommentDto
            {
                PostingId = postingDto.Id,
                comment = postingDto.Comment,
                UserId = currentUser,
            };

            var mapComment = Mapper.Map<CommentDto, Comment>(postComment);

            _context.Comments.Add(mapComment);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri,"/" +postComment.Id),postingDto);
        }
    }
}
