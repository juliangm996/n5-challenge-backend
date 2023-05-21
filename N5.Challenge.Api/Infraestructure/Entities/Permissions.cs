using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5.Challenge.Api.Infraestructure.Entities
{
    public record Permissions : IEntity
    {

        [StringLength(80, MinimumLength = 4)]
        public string NombreEmpleado { get; init; }

        [StringLength(80, MinimumLength = 4)]
        public string ApellidoEmpleado { get; init; }
        public int TipoPermiso { get; init; }
        public DateTime FechaPermio { get; init; }

        //Relation tables
        public virtual PermissionTypes PermissionTypes { get; init; }

    }
}

