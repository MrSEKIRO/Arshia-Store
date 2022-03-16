using Arshia_Store.Common.UserRoles;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.AuthenticationPolicies
{
	public class AdminRequirement : IAuthorizationRequirement
	{
		public AdminRequirement(string role)
		{
			Role = role;
		}

		public string Role { get; }
	}

	public class AdminHandler : AuthorizationHandler<AdminRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
		{
			var roleClaim = context.User.Claims
				.Where(c => c.Type == ClaimTypes.Role)
				.FirstOrDefault();

			if(roleClaim == null)
				return Task.CompletedTask;

			bool isAdmin = roleClaim.Value
				.Contains(requirement.Role);

			if(isAdmin == true)
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
