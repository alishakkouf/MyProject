using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MyProject.Data;

namespace MyProject.Common.MiddleWares
{
    internal class UnitOfWorkMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {
            var httpVerb = context.Request.Method.ToUpper();

            // Use unit of work only if http method modifies system
            if (httpVerb != "POST" && httpVerb != "PUT" && httpVerb != "DELETE")
            {
                await next(context);
                return;
            }

            await unitOfWork.BeginTransactionAsync();

            try
            {
                await next(context);

                if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
                {
                    await unitOfWork.CommitAsync();
                }
                else
                {
                    await unitOfWork.RollBackAsync();
                }
            }
            catch
            {
                await unitOfWork.RollBackAsync();
                throw;
            }
        }
    }

    public static class UnitOfWorkMiddlewareExtensions
    {
        /// <summary>
        /// Use transactional unit of work.
        /// </summary>
        public static IApplicationBuilder UseUnitOfWork(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnitOfWorkMiddleware>();
        }
    }
}
