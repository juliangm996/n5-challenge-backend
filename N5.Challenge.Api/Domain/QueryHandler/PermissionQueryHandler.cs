using System;
using N5.Challenge.Api.Infraestructure;
using N5.Challenge.Api.Infraestructure.Entities;

namespace N5.Challenge.Api.Domain.QueryHandler
{
    public class PermissionQueryHandler
    {

        private readonly IUnitOfWork unitOfWork;

        public PermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       


    }
}


