using System.Net;
using Microsoft.AspNetCore.Mvc;

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
        catch (Exception exception)
        {
            if (context.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                ProblemDetails problem = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = exception.Message,
                    Detail = "An internal server error has occurred",
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
          
        }

        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            //204 NoContent
            if (context.Response.StatusCode == (int)HttpStatusCode.NoContent)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NoContent,
                    Type = "NoContent",
                    Title = e.Message,
                    Detail = "No Content success status response code indicates"

                };
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        try
         {
             await _next(context);
         }
         catch (Exception exception)
         {
             //404 NotFound
             if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
             {
                 context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                 ProblemDetails problemDetails = new ProblemDetails
                 {
                     Status = (int)HttpStatusCode.NotFound,
                     Type = "NotFound",
                     Title = exception.Message,
                     Detail = "The requested resource was not found"
                 };
                 await context.Response.WriteAsJsonAsync(problemDetails);
             }
         }

         try
         {
             await _next(context);

         }
         catch (Exception exception)
         {
             //403 Forbidden
             if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
             {
                 context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                 ProblemDetails problemDetails = new ProblemDetails
                 {
                     Status = (int)HttpStatusCode.Forbidden,
                     Type = "Forbidden",
                     Title = exception.Message,
                     Detail = "access to the requested resource is denied"

                 };
                 await context.Response.WriteAsJsonAsync(problemDetails);

             }

             throw;
         }

         try
         {
             await _next(context);

         }
         catch (Exception exception)
         {
             //401 Unauthorized
             if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
             {
                 context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                 ProblemDetails problemDetails = new ProblemDetails
                 {
                     Status = (int)HttpStatusCode.Unauthorized,
                     Type = "Unauthorized",
                     Title = exception.Message,
                     Detail = "You don’t have access"
                 };
                 await context.Response.WriteAsJsonAsync(problemDetails);

             }
         }

         try
         {
             await _next(context);
         }
         catch (Exception exception)
         {
             //400 BadRequest
             if (context.Response.StatusCode == (int)HttpStatusCode.BadRequest)
             {
                 context.Response.StatusCode = (int)(HttpStatusCode.BadRequest);
                 ProblemDetails problemDetails = new ProblemDetails
                 {
                     Status = (int)HttpStatusCode.BadRequest,
                     Type = "BadRequest",
                     Title = exception.Message,
                     Detail = " Ivalid request message framing"
                 };
                 await context.Response.WriteAsJsonAsync(problemDetails);
             }
         }
    }
}