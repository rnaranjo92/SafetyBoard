using AutoMapper;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SafetyBoard.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<PostingDto, Posting>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Posting, PostingDto>();
            Mapper.CreateMap<PostingType, PostingTypeDto>();
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<UserDto, ApplicationUser>().ForMember(c => c.Id, opt => opt.Ignore()); 
            Mapper.CreateMap<Organization, OrganizationDto>();
            Mapper.CreateMap<OrganizationDto, Organization>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}