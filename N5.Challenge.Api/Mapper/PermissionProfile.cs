using System;
using AutoMapper;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Resources;

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

