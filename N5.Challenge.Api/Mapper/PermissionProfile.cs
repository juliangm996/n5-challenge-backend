using System;
using AutoMapper;
using N5.Challenge.Api.Infraestructure.Entities;
using N5.Challenge.Api.Infraestructure.Resources;

namespace N5.Challenge.Api.Mapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permissions, PermissionResource>().ReverseMap();
        }
    }
}

