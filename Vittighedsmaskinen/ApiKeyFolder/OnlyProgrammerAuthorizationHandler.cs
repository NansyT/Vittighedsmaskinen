using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen.ApiKeyFolder
{
    public class OnlyProgrammerAuthorizationHandler : AuthorizationHandler<OnlyProgrammerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyProgrammerRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Programmer))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
