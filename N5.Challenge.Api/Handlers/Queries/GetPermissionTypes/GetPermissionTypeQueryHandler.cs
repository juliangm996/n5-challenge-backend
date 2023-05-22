using AutoMapper;
using ErrorOr;
using MediatR;
using N5.Challenge.Api.Entities;
using N5.Challenge.Api.Kafka;
using N5.Challenge.Api.Repositories;
using N5.Challenge.Api.Resources;

namespace N5.Challenge.Api.Handlers.Queries.GetPermissionTypes
{
    public class GetPermissionTypeQueryHandler : IRequestHandler<GetPermissionTypesQuery, ErrorOr<IEnumerable<PermissionTypeResource>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KafkaProducer _kafkaProducer;

        public GetPermissionTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, KafkaProducer kafkaProducer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }


        public async Task<ErrorOr<IEnumerable<PermissionTypeResource>>> Handle(GetPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            var permissionType = await _unitOfWork.Repository().FindAllAsync<PermissionTypes>();

            return _mapper.Map<List<PermissionTypeResource>>(permissionType);
        }
    }
}
