using System;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Infraestructure.Entities
{
    public class Permissions
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string NombreEmpleado { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermio { get; set; }

        //Relation tables
        public virtual PermissionTypes PermissionTypes { get; set; }

    }
}

