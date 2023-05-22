﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace N5.Challenge.Api.Errors
{
    public class N5ChallengeExceptionHandlerAttribute :  ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails
            {
                Title = "An error occupied while processing your request",
                Instance = context.HttpContext.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            };
            context.Result = new ObjectResult(problemDetails);
        }
    }
}
