using ErrorOr;
using MediatR;
using N5.Challenge.Api.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace N5.Challenge.Api.Handlers.Commands.RequestPermisssions
{
    public class RequestPermissionCommand : IRequest<ErrorOr<PermissionResource>>
    {
        public string? NombreEmpleado { get; set; }
        public string? ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }

    }
}

