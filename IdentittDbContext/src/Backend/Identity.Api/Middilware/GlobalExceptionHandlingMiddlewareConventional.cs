﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace Identity.Api.Middilware;

public class GlobalExceptionHandlingMiddlewareConventional
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddlewareConventional> _logger;
    public GlobalExceptionHandlingMiddlewareConventional(RequestDelegate next,
                                                         ILogger<GlobalExceptionHandlingMiddlewareConventional> logger)
    {
        _next = next;
        _logger = logger;
    }
      public async Task InvokeAsync(HttpContext context)
    {
        //500 ServerError
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = HttpStatusCode.InternalServerError.GetDisplayName(),
                Detail = "An internal server error has occurred"
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
        //204 NoContent
        if (context.Response.StatusCode == (int)HttpStatusCode.NoContent)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NoContent,
                Type = "NoContent",
                Title = HttpStatusCode.NoContent.GetDisplayName(),
                Detail = "No Content success status response code indicates"

            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        //404 NotFound
        if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "NotFound",
                Title = HttpStatusCode.NotFound.GetDisplayName(),
                Detail = "The requested resource was not found"
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        //403 Forbidden
        if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = "Forbidden",
                Title = HttpStatusCode.Forbidden.GetDisplayName(),
                Detail = "access to the requested resource is denied"

            };
            await context.Response.WriteAsJsonAsync(problemDetails);

        }
        //401 Unauthorized
        if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.Unauthorized,
                Type = "Unauthorized",
                Title = HttpStatusCode.Unauthorized.GetDisplayName(),
                Detail = "You don’t have access"
            };
            await context.Response.WriteAsJsonAsync(problemDetails);

        }
        //400 BadRequest
        if (context.Response.StatusCode == (int)HttpStatusCode.BadRequest)
        {
            context.Response.StatusCode = (int)(HttpStatusCode.BadRequest);
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Type = "BadRequest",
                Title = HttpStatusCode.BadRequest.GetDisplayName(),
                Detail = " Ivalid request message framing"
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }    }
}