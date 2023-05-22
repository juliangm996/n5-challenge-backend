using System;
using AutoMapper;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Resources;

namespace N5.Challenge.Api.Mapper
{
    public class PermissionTypeProfile : Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionTypes, PermissionTypeResource>().ReverseMap();
        }
    }
}

