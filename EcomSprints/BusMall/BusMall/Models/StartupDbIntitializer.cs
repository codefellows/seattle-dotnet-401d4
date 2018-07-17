using BusMall.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMall.Models
{
    public class StartupDbIntitializer
    {

		private const string AdminEmail = "admin@admin.com";
		private const string AdminPassword = "StrongPasswordAdmin123!";

		private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
		{
			new IdentityRole {Name = ApplicationRoles.Admin,
				NormalizedName = ApplicationRoles.Admin.ToUpper(),
				ConcurrencyStamp = Guid.NewGuid().ToString()},
			new IdentityRole {Name = ApplicationRoles.Member,
				NormalizedName = ApplicationRoles.Member.ToUpper(),
				ConcurrencyStamp = Guid.NewGuid().ToString()}

		};

		public static void SeedData(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
		{
			using (var dbContext =
				new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{
				dbContext.Database.EnsureCreated();
				AddRoles(dbContext);
				//AddUser(dbContext, userManager);
				//AddUserRoles(dbContext);
			}

		}

		private static void AddRoles(ApplicationDbContext dbContext)
		{
			if (dbContext.Roles.Any()) return;
			foreach (var role in Roles)
			{
				dbContext.Roles.Add(role);
				dbContext.SaveChanges();
			}
		}

		//private static async void AddUser(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
		//{
		//	if (dbContext.Users.Any()) return;
		//	var user = new ApplicationUser()
		//	{
		//		UserName = AdminEmail,
		//		Email = AdminEmail,
		//		EmailConfirmed = true,
		//	};
		//	await userManager.CreateAsync(user, AdminPassword);
		//}

		//private static void AddUserRoles(ApplicationDbContext dbContext)
		//{
		//	if (dbContext.UserRoles.Any()) return;
		//	var userRole = new IdentityUserRole<string>
		//	{
		//		UserId = dbContext.Users.Single(r => r.Email == AdminEmail).Id,
		//		RoleId = dbContext.Roles.Single(r => r.Name == ApplicationRoles.Admin).Id
		//	};
		//	dbContext.UserRoles.Add(userRole);
		//	dbContext.SaveChanges();
		//}
	}
}
