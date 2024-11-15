using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using tukun_tech_platform.IAM.Domain.Model.Aggregates;

namespace tukun_tech_platform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
        {
            Console.WriteLine(" Skipping Authorization");
            return;
        }

        var user = (User?)context.HttpContext.Items["User"];
        if (user == null) context.Result = new UnauthorizedResult();
    }
}
