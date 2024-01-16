using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MyProject.Shared.ResultDtos;
using Newtonsoft.Json;

namespace MyProject.Common.MiddleWares
{
    internal class ResultWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResultWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isApi = context.Request.Path.ToString().Contains("/api/");
            var isExport = context.Request.Path.ToString().Contains("Export");

            // If request has not the pattern "/api/[controller]", then skip the middleware.
            // Or if request contains "Export" which returns a report file.
            // This is necessary for identity server endpoints.
            if (!isApi || isExport)
            {
                await _next(context);
                return;
            }

            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    //set the current response to the memoryStream.
                    context.Response.Body = memoryStream;

                    await _next(context);

                    if (context.Response.HasStarted) { return; }

                    //reset the body
                    context.Response.Body = currentBody;
                    var successful = context.Response.StatusCode >= 200 && context.Response.StatusCode <= 299;

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var readToEnd = new StreamReader(memoryStream).ReadToEnd();

                    var wrappedResult = successful ?
                        new WrappedResultDto(JsonConvert.DeserializeObject(readToEnd), context.Response.StatusCode) :
                        new WrappedResultDto(JsonConvert.DeserializeObject<ErrorResultDto>(readToEnd), context.Response.StatusCode);

                    // Handle returning empty result like Ok()
                    if (string.IsNullOrEmpty(context.Response.ContentType))
                        context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(JsonCamelCaseSerializer.Serialize(wrappedResult));
                }
                catch
                {
                    if (!context.Response.HasStarted)
                        context.Response.Body = currentBody;
                    throw;
                }
            }
        }
    }

    public static class ResultWrapperMiddlewareExtensions
    {
        /// <summary>
        /// Wrap results with <see cref="WrappedResultDto"/>.
        /// </summary>
        public static IApplicationBuilder UseResultWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResultWrapperMiddleware>();
        }
    }
}
