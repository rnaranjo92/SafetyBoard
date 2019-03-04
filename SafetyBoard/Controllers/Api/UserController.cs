using AutoMapper;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace SafetyBoard.Controllers.Api
{
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        //Get Users
        public IHttpActionResult GetUsers()
        {
            var users = _context.Users.Include(c=>c.Organization).ToList().Select(Mapper.Map<ApplicationUser, UserDto>);

            return Ok(users);
        }
        public IHttpActionResult GetUser(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return BadRequest();

            return Ok(user);
        }
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = Mapper.Map<UserDto, ApplicationUser>(userDto);

            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;
            return Created(new Uri(Request.RequestUri + "/" + user.Id),userDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateUser(string id,UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userinDb = _context.Users.SingleOrDefault(c => c.Id == id);

            if (userinDb == null)
                return BadRequest();

            Mapper.Map(userDto, userinDb);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {
            var userinDb = _context.Users.SingleOrDefault(c => c.Id == id);

            if (userinDb == null)
                return BadRequest();

            _context.Users.Remove(userinDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
