using FluentValidation;

namespace N5.Challenge.Api.Handlers.Commands.RequestPermisssions
{
    public class RequestPermissionValidator : AbstractValidator<RequestPermissionCommand>
    {
        public RequestPermissionValidator()
        {
            RuleFor(x => x.ApellidoEmpleado).NotEmpty();
            RuleFor(x => x.NombreEmpleado).NotEmpty();
            RuleFor(x => x.TipoPermiso).NotEmpty();
        }
    }
}
