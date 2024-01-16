using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MyProject.Shared;
using MyProject.Shared.Exceptions;
using MyProject.Shared.ResultDtos;

namespace MyProject.Common.MiddleWares
{
    public static class ExceptionMiddleware
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var factory = app.ApplicationServices.GetService<IStringLocalizerFactory>();
                    var localizer = factory.Create(typeof(CommonResource));

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        var exception = contextFeature.Error;

                        // Access the ILogger<T> from the application services
                        var logger = context.RequestServices.GetRequiredService<ILogger<BaseApiController>>();
                        logger.LogError($"Something went wrong: {exception}");
                        int code;
                        ErrorResultDto error;
                        switch (exception)
                        {
                            case ValidationException validationException:
                                code = (int)HttpStatusCode.BadRequest;
                                error = new ErrorResultDto(validationException.Message, string.Join(", ", validationException.ValidationResult.MemberNames));
                                break;
                            case EntityNotFoundException notFoundException:
                                code = (int)HttpStatusCode.NotFound;
                                error = new ErrorResultDto(localizer["EntityNotFound{1}", notFoundException.EntityName, notFoundException.EntityId]);
                                break;
                            case BusinessException businessException:
                                code = (int)HttpStatusCode.BadRequest;
                                error = new ErrorResultDto(businessException.Message);
                                break;
                            default:
                                code = (int)HttpStatusCode.InternalServerError;
                                error = new ErrorResultDto(localizer["InternalServerError"]);
                                break;
                        }

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = code;

                        var result = JsonCamelCaseSerializer.Serialize(new WrappedResultDto(error, code));

                        await context.Response.WriteAsync(result);
                    }
                });
            });
        }
    }
}
