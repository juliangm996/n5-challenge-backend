using System;
using N5.Challenge.Api.Infraestructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Infraestructure.Resources
{
	public class PermissionTypeResource
	{
        public int Id { get; set; }
        public string Descripcion { get; init; }
        public IList<Permissions>? Permissions { get; init; }
    }
}

