using AutoMapper;
using ErrorOr;
using MediatR;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Repositories;
using N5.Challenge.Api.Resources;
using Nest;

namespace N5.Challenge.Api.Handlers.Commands.RequestPermisssions
{
    public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, ErrorOr<PermissionResource>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IElasticClient _elasticClient;

        public RequestPermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IElasticClient elasticClient)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _elasticClient = elasticClient;
        }

        public async Task<ErrorOr<PermissionResource>> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permissions
            {
                ApellidoEmpleado = request.ApellidoEmpleado,
                FechaPermiso = DateTime.Now,
                NombreEmpleado = request.NombreEmpleado,
                TipoPermiso = request.TipoPermiso
            };
            _unitOfWork.Repository().Add(permission);
            var indexResponse = await _elasticClient.IndexAsync(permission, idx => idx.Index("permission_index"));
            /* Only accept insert if es is OK
           if (!indexResponse.IsValid)
               return default;
            */
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<PermissionResource>(permission);
        }
    }
}
