using System;
using AutoMapper;
using N5.Challenge.Api.Infraestructure.Entities;
using N5.Challenge.Api.Infraestructure.Resources;

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

