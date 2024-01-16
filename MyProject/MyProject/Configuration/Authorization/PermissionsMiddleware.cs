using MyProject.Common.Extensions;
using MyProject.Domain.Business;

namespace MyProject.Configuration.Authorization
{
    internal class PermissionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PermissionsMiddleware> _logger;

        public PermissionsMiddleware(
            RequestDelegate next,
            ILogger<PermissionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context,
            IRolePermissionsService permissionService, IBusinessManager BusinessManager)
        {
            if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }

            var cancellationToken = context.RequestAborted;
            var BusinessId = context.User.GetBusinessId();

            // if Business not active then skip permissions and return Unauthorized
            if (BusinessId.HasValue && !await BusinessManager.IsActiveBusinessAsync(BusinessId.Value))
            {
                await _next(context);
                return;
            }

            var userId = context.User.GetUserId();

            if (userId.HasValue)
            {
                var permissionsIdentity = await permissionService.GetUserPermissionsIdentity(userId.Value, cancellationToken);
                if (permissionsIdentity != null)
                {
                    context.User.AddIdentity(permissionsIdentity);
                }
            }

            await _next(context);
        }
    }
}
