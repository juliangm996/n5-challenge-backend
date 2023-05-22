using AutoMapper;
using Elasticsearch.Net;
using ErrorOr;
using MediatR;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Kafka;
using N5.Challenge.Api.Repositories;
using N5.Challenge.Api.Resources;
using Nest;

namespace N5.Challenge.Api.Handlers.Commands.ModifyPermissions
{
    public class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionCommand, ErrorOr<PermissionResource>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IElasticClient _elastic;
        private readonly KafkaProducer _kafkaProducer;


        public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IElasticClient elastic, KafkaProducer kafkaProducer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _elastic = elastic;
            _kafkaProducer = kafkaProducer;
        }

        public async Task<ErrorOr<PermissionResource>> Handle(ModifyPermissionCommand request, CancellationToken cancellation)
        {
            var permission = await _unitOfWork.Repository().GetById<Permissions>(request.Id);

            if (permission is null)
                return default;
            permission = new Permissions
            {
                Id = permission.Id,
                ApellidoEmpleado = request.ApellidoEmpleado,
                FechaPermiso = DateTime.Now,
                NombreEmpleado = request.NombreEmpleado,
                TipoPermiso = request.TipoPermiso,
            };
            
            _unitOfWork.Repository().Update<Permissions>(permission);

            var updateResponse = await _elastic.UpdateAsync<Permissions>(permission.Id, u => u
            .Index("permission_index")
            .Doc(permission)
            .Refresh(Refresh.True));
            
            /* Only accept insert if es is OK
            if(!updateResponse.IsValid)
                return default;
            */
            await _unitOfWork.CommitAsync(cancellation);
            await _kafkaProducer.PublishPermissionOperationAsync("modify");


            return _mapper.Map<PermissionResource>(permission);


        }
    }
}
