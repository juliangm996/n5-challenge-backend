using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Challenge.Api.Handlers.Commands.ModifyPermissions;
using N5.Challenge.Api.Handlers.Commands.RequestPermisssions;
using N5.Challenge.Api.Handlers.Queries;
using N5.Challenge.Api.Handlers.Queries.GetPermissions;
using N5.Challenge.Api.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace N5.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ApiController
    {

        private readonly ISender _mediator;

        public PermissionController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorOr.ErrorOr))]
        public async Task<IActionResult> GetPermissions()
        {
            var query = new GetPermissionsQuery();
            var result = await _mediator.Send(query);
            return result.Match(resp => StatusCode((int)HttpStatusCode.OK, resp),
                errors => Problem(errors));
        }


        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorOr.ErrorOr))]
        public async Task<IActionResult> RequestPermissions([FromBody] RequestPermissionCommand request)
        {
            var result = await _mediator.Send(request);
            return result.Match(resp => StatusCode((int)HttpStatusCode.OK, resp),
                errors => Problem(errors));
        }


        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorOr.ErrorOr))]
        public async Task<IActionResult> ModifyPermission([FromBody] ModifyPermissionCommand request)
        {
            var result = await _mediator.Send(request);
            return result.Match(resp => StatusCode((int)HttpStatusCode.OK, resp),
                errors => Problem(errors));
        }

        
    }
}

