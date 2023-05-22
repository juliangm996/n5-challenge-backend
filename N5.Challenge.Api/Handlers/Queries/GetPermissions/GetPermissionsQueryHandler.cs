using AutoMapper;
using ErrorOr;
using MediatR;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Kafka;
using N5.Challenge.Api.Repositories;
using N5.Challenge.Api.Resources;

namespace N5.Challenge.Api.Handlers.Queries.GetPermissions
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, ErrorOr<IEnumerable<PermissionResource>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KafkaProducer _kafkaProducer;

        public GetPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, KafkaProducer kafkaProducer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }


        public async Task<ErrorOr<IEnumerable<PermissionResource>>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _unitOfWork.Repository().FindAllAsync<Permissions>();

            await _kafkaProducer.PublishPermissionOperationAsync("get");

            return _mapper.Map<List<PermissionResource>>(permissions);
        }
    }
}
