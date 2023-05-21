using System;
using N5.Challenge.Api.Infraestructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Domain.Command
{
    public class RequestPermissionCommand
    {
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermio { get; set; }

    }
}

