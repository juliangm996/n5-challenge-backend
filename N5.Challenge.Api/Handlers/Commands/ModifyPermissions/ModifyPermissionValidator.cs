using FluentValidation;

namespace N5.Challenge.Api.Handlers.Commands.ModifyPermissions
{
    public class ModifyPermissionValidator : AbstractValidator<ModifyPermissionCommand>
    {
        public ModifyPermissionValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();

        }
    }
}
