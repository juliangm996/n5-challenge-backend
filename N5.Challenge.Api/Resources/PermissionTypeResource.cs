using System;
using System.ComponentModel.DataAnnotations;
using N5.Challenge.Api.Entities;

namespace N5.Challenge.Api.Resources
{
    public class PermissionTypeResource
    {
        public int Id { get; set; }
        public string Descripcion { get; init; }
        public IList<Permissions>? Permissions { get; init; }
    }
}

