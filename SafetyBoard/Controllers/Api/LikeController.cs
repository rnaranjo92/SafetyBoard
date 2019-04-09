using Microsoft.AspNet.Identity;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System.Linq;
using System.Web.Http;

namespace SafetyBoard.Controllers.Api
{
    [Authorize]
    public class LikeController : ApiController
    {
        private ApplicationDbContext _context;

        public LikeController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Like(LikeDto likeDto)
        {
            var currentUser = User.Identity.GetUserId();

            if (_context.Like.Any(l => l.LikerId == currentUser && l.SafetyNewsId == likeDto.SafetyNewsId))
                return BadRequest("Like Duplicate");

            var like = new Like
            {
                SafetyNewsId = likeDto.SafetyNewsId,
                LikerId = User.Identity.GetUserId()
            };
            _context.Like.Add(like);
            _context.SaveChanges();

            return Ok();
        }
    }
}
