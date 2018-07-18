using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusMall.Models.Handlers
{
	public class RequiredEmailHandler : AuthorizationHandler<RequiredEmailRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequiredEmailRequirement requirement)
		{

			if (!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
			{
				return Task.CompletedTask;
			}

			var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;


			if (userEmail.Contains(requirement.Email))
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;

		}
	}
}
