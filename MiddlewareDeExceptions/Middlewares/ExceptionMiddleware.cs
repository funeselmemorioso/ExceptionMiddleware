using Microsoft.AspNetCore.Http;
using MiddlewareDeExceptions.Middlewares.Entities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MiddlewareDeExceptions.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
       
        public ExceptionMiddleware(RequestDelegate next)
        {      
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {              
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "El middleware responde : " + exception.Message
            }.ToString());
        }
    }
}
