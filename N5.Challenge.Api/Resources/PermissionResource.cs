using System;
using System.ComponentModel.DataAnnotations;
using N5.Challenge.Api.Entities;

namespace N5.Challenge.Api.Resources
{
    public class PermissionResource
    {
        public int Id { get; init; }
        public string NombreEmpleado { get; init; }
        public string ApellidoEmpleado { get; init; }
        public int TipoPermiso { get; init; }
        public DateTime FechaPermiso { get; init; }
        public PermissionTypes PermissionTypes { get; init; }
    }
}

