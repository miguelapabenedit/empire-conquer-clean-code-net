using Microsoft.AspNetCore.Authorization;
using Core.Enums;

namespace Core.Entities
{
    public class Policies
    {
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(RoleType.Admin.ToString()).Build();
        }

        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
             .RequireRole(RoleType.User.ToString()).Build();
        }
    }
}
