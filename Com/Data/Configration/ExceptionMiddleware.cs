
using Com.Core.EntitiesException;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Com.Data.Configration
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);

            }
            catch (Exception ex)
            {
                await HandleExcpetionAsync(context, ex);
            }
        }

        private static Task HandleExcpetionAsync(HttpContext context, Exception ex)
        {

            int statuscode = StatusCodes.Status500InternalServerError;

            switch (ex)
            {
                case NotFoundException _:
                    statuscode = StatusCodes.Status404NotFound; break;

                case BadRequestException _:
                    statuscode = StatusCodes.Status400BadRequest; break;
  
            }

            var error = new ErrorResponse
            {
                StatusCode = statuscode,
                Message = ex.Message,
            };


            var json = JsonSerializer.Serialize(error);  

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statuscode;
            return context.Response.WriteAsync(json);


        }

    }
}
