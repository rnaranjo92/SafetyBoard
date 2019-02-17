using AutoMapper;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SafetyBoard.Controllers.Api
{
    public class OrganizationController : ApiController
    {
        private ApplicationDbContext _context;

        public OrganizationController()
        {
            _context = new ApplicationDbContext();
        }

        //GetOrganization
        public IHttpActionResult GetOrganizations()
        {
            var organization = _context.Organizations.ToList().Select(Mapper.Map<Organization,OrganizationDto>);

            return Ok(organization);
        }
        public IHttpActionResult GetOrganization(int id)
        {
            var organization = _context.Organizations.SingleOrDefault(c => c.Id == id);

            if (organization == null)
                return NotFound();

            return Ok(Mapper.Map<Organization, OrganizationDto>(organization));
        }
        [HttpPost]
        public IHttpActionResult CreateOrganization(OrganizationDto organizationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var organization = Mapper.Map<OrganizationDto, Organization>(organizationDto);

            _context.Organizations.Add(organization);
            _context.SaveChanges();

            organizationDto.Id = organization.Id;

            return Created(new Uri(Request.RequestUri,"/"+ organization.Id), organizationDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateOrganization(int id, OrganizationDto organizationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var orgInDb = _context.Organizations.SingleOrDefault(c => c.Id == id);

            if (orgInDb == null)
                return NotFound();

            Mapper.Map(organizationDto, orgInDb);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteOrganization(int id)
        {
            var organization = _context.Organizations.SingleOrDefault(c => c.Id== id);
            if (organization == null)
                return NotFound();

            _context.Organizations.Remove(organization);
            _context.SaveChanges();

            return Ok();
        }
    }
}
