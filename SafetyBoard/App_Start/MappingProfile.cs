using AutoMapper;
using SafetyBoard.Dto;
using SafetyBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetyBoard.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<PostingDto, Posting>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Posting, PostingDto>();
            Mapper.CreateMap<PostingType, PostingTypeDto>();

        }
    }
}