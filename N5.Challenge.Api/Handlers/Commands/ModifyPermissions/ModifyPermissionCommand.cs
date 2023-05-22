using ErrorOr;
using MediatR;
using N5.Challenge.Api.Resources;

namespace N5.Challenge.Api.Handlers.Commands.ModifyPermissions
{
    public class ModifyPermissionCommand :  IRequest<ErrorOr<PermissionResource>>
    {
        public int Id { get; set; }
        public string? NombreEmpleado { get; set; }
        public string? ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
    }
}
