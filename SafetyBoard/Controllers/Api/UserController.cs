using AutoMapper;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SafetyBoard.Controllers.Api
{
    [Authorize]
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/users

        public IHttpActionResult GetUsers()
        {
            var userDto = _context.Users.Include(u=>u.UserType).ToList().Select(Mapper.Map<User, UserDto>);

            return Ok(userDto);
        }

        //GET /api/users/1

        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<User, UserDto>(user));
        }

        //POST /api/user
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<UserDto, User>(userDto);

            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;


            return Created(new Uri(Request.RequestUri,"/" +user.Id),userDto);
        }

        //PUT
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userinDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userinDb == null)
                return NotFound();

            Mapper.Map(userDto, userinDb);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}
