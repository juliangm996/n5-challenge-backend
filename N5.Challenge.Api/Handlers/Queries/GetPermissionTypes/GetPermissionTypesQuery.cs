using ErrorOr;
using MediatR;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Resources;

namespace N5.Challenge.Api.Handlers.Queries.GetPermissionTypes
{
    public class GetPermissionTypesQuery : IRequest<ErrorOr<IEnumerable<PermissionTypeResource>>>
    {
    }
}
