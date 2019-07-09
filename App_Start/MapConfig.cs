using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using cloudrest.Dtos;
using cloudrest.Models;

namespace cloudrest.App_Start
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>()
                .ForMember(m => m.UserId,opt => opt.Ignore());

            Mapper.CreateMap<Lesson, LessonDto>();
            Mapper.CreateMap<LessonDto, Lesson>()
                .ForMember(m => m.LessonId, opt => opt.Ignore());

            Mapper.CreateMap<Selection, SelectionDto>();
            Mapper.CreateMap<SelectionDto, Selection>()
                .ForMember(m => m.SelectionId, opt => opt.Ignore());

            
        }
    }
}