using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMall.Models.Handlers
{
	public class RequiredEmailRequirement : IAuthorizationRequirement
	{
		public RequiredEmailRequirement(string email)
		{
			Email = email;
		}

		public string Email { get; set; }
	}

}
