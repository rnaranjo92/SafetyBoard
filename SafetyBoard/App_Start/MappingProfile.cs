using AutoMapper;
using SafetyBoard.Controllers.Api;
using SafetyBoard.Dto;
using SafetyBoard.Models;

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
            Mapper.CreateMap<CommentDto, Comment>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Inspection, InspectionDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<SafetyNews, SafetyNewsDto>();
            Mapper.CreateMap<SafetyNewsDto, SafetyNews>();


        }
    }
}