using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cohort4ECommerce.Models;
using Cohort4ECommerce.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cohort4ECommerce.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel rvm)
		{
			if (ModelState.IsValid)
			{
				List<Claim> claims = new List<Claim>();
				var user = new ApplicationUser
				{
					UserName = rvm.Email,
					Email = rvm.Email,
					FirstName = rvm.FirstName,
					LastName = rvm.LastName,
					Birthday = rvm.Birthday
				};

				var result = await _userManager.CreateAsync(user, rvm.Password);

				if (result.Succeeded)
				{
					Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
					Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth,
						new DateTime(user.Birthday.Year,
						user.Birthday.Month,
						user.Birthday.Day)
						.ToString("u"),
						ClaimValueTypes.DateTime);
					Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

					claims.Add(nameClaim);
					claims.Add(birthdayClaim);
					claims.Add(emailClaim);


					//await _userManager.AddClaimAsync(user, nameClaim);
					await _userManager.AddClaimsAsync(user, claims);

					if (user.Email == "amanda@codefellows.com")
					{
						await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
						await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

					}
					else
					{
						await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

					}

					await _signInManager.SignInAsync(user, false);

					return RedirectToAction("Index", "Home");
				}
			}


			return View(rvm);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel lvm)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager
					.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

				if (result.Succeeded)
				{
					if (User.IsInRole(ApplicationRoles.Admin))
					{
						return RedirectToAction("Index", "Admin");
					}

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError
						(string.Empty, "You don't know your credentials");
				}

			}

			return View(lvm);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			TempData["LoggedOut"] = "User Logged Out";

			return RedirectToAction("Index", "Home");
		}
	}
}