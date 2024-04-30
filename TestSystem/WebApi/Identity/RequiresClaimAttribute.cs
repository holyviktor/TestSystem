using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TestSystem.WebApi.Identity
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresClaimAttribute : Attribute, IAuthorizationFilter
    {

        private readonly string _claimName;
        private readonly string _claimValue;

        public RequiresClaimAttribute(string claimName, string claimValue)
        {
            _claimValue = claimValue;
            _claimName = claimName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine(_claimValue + " " + _claimName);
            if (!context.HttpContext.User.HasClaim(_claimName, _claimValue))
            {
                context.Result = new ForbidResult();
                Console.WriteLine("forbidden");
            }
        }
    }
}
