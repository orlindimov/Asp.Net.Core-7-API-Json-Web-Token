using Jwt.API.Exceptions;
using Jwt.Core.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Jwt.API.Extensions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        ErrorDto errorDto = null;

                        if (ex is CustomException)
                        {
                            errorDto = new ErrorDto(ex.Message, true);
                        }
                        else
                        {
                            errorDto = new ErrorDto(ex.Message, false);
                        }

                        var response = Response<NoContent>.Fail(errorDto, 500);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
