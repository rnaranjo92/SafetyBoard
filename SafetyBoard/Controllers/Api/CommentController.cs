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

        //[HttpPost]
        //public IHttpActionResult Comment(SafetyNewsDto safetyNewsDto)
        //{
        //    var currentUser = User.Identity.GetUserId();
        //    var article = _context.SafetyNews.Single(sn => sn.Id == safetyNewsDto.Id);
        //    if(article == null)
        //    {
        //        return NotFound();
        //    }
        //    var comment = new CommentDto(article.Id, safetyNewsDto.Comment, currentUser);
        //    var mapComment = Mapper.Map<CommentDto, Comment>(comment);
        //    _context.Comments.Add(mapComment);
        //    _context.SaveChanges();
        //    return Created(new Uri(Request.RequestUri, "/" + comment.Id), safetyNewsDto);
        //}
    }
}
