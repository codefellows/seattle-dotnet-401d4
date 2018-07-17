using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusMall.Models;
using BusMall.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusMall.Controllers
{
    public class AccountController : Controller
    {
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;

		/// <summary>
		/// Constructor that is bringing in the User and Signin Manager to handle account specific costs
		/// </summary>
		/// <param name="userManager">userManager</param>
		/// <param name="signInManager">signInManager</param>
		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;

		}

		/// <summary>
		/// Default Get for Register Page
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Register() => View();

		/// <summary>
		/// Postback for register page after user submits form
		/// </summary>
		/// <param name="rvm">The information in the form that the user has submitted</param>
		/// <returns>redirect to approraite view</returns>
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel rvm)
		{
			if (ModelState.IsValid)
			{
				//Create a new Application User
				ApplicationUser user = new ApplicationUser()
				{
					UserName = rvm.Email,
					Email = rvm.Email,
					FirstName = rvm.FirstName,
					LastName = rvm.LastName,
					Birthday = rvm.Birthday
				};
				var result = await _userManager.CreateAsync(user, rvm.Password);

				// Only add claims and sign the user in if the user was successfully created
				if(result.Succeeded)
				{
					List<Claim> myclaims = new List<Claim>();

					Claim claim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
					Claim bdClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year,
						user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
					Claim claimemail = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

					myclaims.Add(claim);
					myclaims.Add(bdClaim);
					myclaims.Add(claimemail);

					await _userManager.AddClaimsAsync(user, myclaims);

					if(rvm.Email.ToLower() == "amanda@codefellows.com")
					{
						await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

					}
					await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
					await _signInManager.SignInAsync(user, isPersistent: false);

					return RedirectToAction("Index", "Home");

				}

			}

			//Redirect back to the Register page with the model that contains the errors.
			return View(rvm);
		}

		/// <summary>
		/// Get the login page
		/// </summary>
		/// <returns>View for login page</returns>
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		/// <summary>
		/// Post for Login page. Signs the user in
		/// </summary>
		/// <param name="lvm">The form that the user filled out on Login page</param>
		/// <returns>Redirect to appropriate page</returns>
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel lvm)
		{
			if(ModelState.IsValid)
			{
				var result = await _signInManager
					.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);
				if(result.Succeeded)
				{
					var user = await  _userManager.FindByEmailAsync(lvm.Email);
					if(await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
					{
						return RedirectToAction("Index",  "Admin");
					}
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Invalid login attempt.");

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