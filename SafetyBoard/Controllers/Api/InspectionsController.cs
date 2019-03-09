using Microsoft.AspNet.Identity;
using SafetyBoard.Models;
using System.Linq;
using System.Web.Http;

namespace SafetyBoard.Controllers.Api
{
    [Authorize]
    public class InspectionsController : ApiController
    {
        private ApplicationDbContext _context;

        public InspectionsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var inspection = _context.Inspections.Single(i => i.Id == id && i.UserId == userId);

            if (inspection.IsCanceled)
                return NotFound();

            inspection.IsCanceled = true;

            var notification = Notification.InspectionCanceled(inspection);

            var users = _context.Users.
                Where(u => u.OrganizationId == inspection.OrganizationId)
                .ToList();

            foreach(var user in users)
            {
                user.Notify(notification);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
