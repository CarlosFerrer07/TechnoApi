using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace TechnoApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next; 
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                if (ex is UnauthorizedAccessException)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                var response = new { mensaje = ex.Message };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
