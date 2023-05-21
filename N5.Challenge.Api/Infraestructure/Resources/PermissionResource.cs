using System;
using N5.Challenge.Api.Infraestructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Infraestructure.Resources
{
	public class PermissionResource
	{
        public int Id { get; init; }
        public string NombreEmpleado { get; init; }
        public string ApellidoEmpleado { get; init; }
        public int TipoPermiso { get; init; }
        public DateTime FechaPermio { get; init; }        
        public PermissionTypes PermissionTypes { get; init; }
    }
}

