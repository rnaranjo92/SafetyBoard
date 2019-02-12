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
    public class PostingController : ApiController
    {
        private ApplicationDbContext _context;

        public PostingController()
        {
            _context = new ApplicationDbContext();
        }

        //GET POSTS

        public IHttpActionResult GetPosts()
        {
            var posting = _context.Postings.Include(p=>p.PostingType).ToList().Select(Mapper.Map<Posting, PostingDto>);

            return Ok(posting);
        }

        //GET POST
        public IHttpActionResult GetPost(int id)
        {
            var posting = _context.Postings.SingleOrDefault(p => p.Id == id);

            if (posting == null)
                return NotFound();

            return Ok(Mapper.Map<Posting, PostingDto>(posting));
        }

        //CREATE POST
        [HttpPost]
        public IHttpActionResult CreatePost(PostingDto postingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var posting = Mapper.Map<PostingDto, Posting>(postingDto);

            _context.Postings.Add(posting);
            _context.SaveChanges();

            postingDto.Id = posting.Id;

            return Created(new Uri(Request.RequestUri, "/" + posting.Id),postingDto);
        }

        //UPDATE POST
        [HttpPut]
        public IHttpActionResult UpdatePost(int id, PostingDto postingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var postingInDb = _context.Postings.SingleOrDefault(p => p.Id == id);

            if (postingInDb == null)
                return NotFound();

            Mapper.Map(postingDto, postingInDb);



            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        //Delete POST
        public IHttpActionResult DeletePost(int id)
        {
            var posting = _context.Postings.SingleOrDefault(p => p.Id == id);

            _context.Postings.Remove(posting);

            _context.SaveChanges();

            return Ok();
        }
    }
}
