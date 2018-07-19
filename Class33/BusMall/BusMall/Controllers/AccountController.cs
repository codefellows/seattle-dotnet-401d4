using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusMall.Models;
using BusMall.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BusMall.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;
		private IEmailSender _emailSender;
		/// <summary>
		/// Constructor that is bringing in the User and Signin Manager to handle account specific costs
		/// </summary>
		/// <param name="userManager">userManager</param>
		/// <param name="signInManager">signInManager</param>
		public AccountController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_emailSender = emailSender;


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
				if (result.Succeeded)
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

					if (rvm.Email.ToLower() == "amanda@codefellows.com")
					{
						await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

					}
					await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
					await _signInManager.SignInAsync(user, isPersistent: false);

					await _emailSender.SendEmailAsync(user.Email, "Welcome", "<p>Thank you for registering </p>");

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
			if (ModelState.IsValid)
			{
				var result = await _signInManager
					.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);
				if (result.Succeeded)
				{
					var user = await _userManager.FindByEmailAsync(lvm.Email);
					await _emailSender.SendEmailAsync(user.Email, "Thank you for logging in", 
						"<p>Thank you for logging in </p>");

					if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
					{
						return RedirectToAction("Index", "Admin");
					}
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Invalid login attempt.");

			}
			return View(lvm);
		}

		/// <summary>
		/// Log the user out of the session
		/// </summary>
		/// <returns>completion of a task</returns>
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			TempData["LoggedOut"] = "User Logged Out";

			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// This is the first step when working with external providers such as OAUTH service providers.
		/// </summary>
		/// <param name="provider"></param>
		/// <returns></returns>
		public IActionResult ExternalLogin(string provider)
		{
			var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return Challenge(properties, provider);
		}

		/// <summary>
		/// Gets called after the call to the 3rd party connection is made. 
		/// </summary>
		/// <param name="remoteError"></param>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginCallback(string remoteError = null)
		{
			if (remoteError != null)
			{
				TempData["ErrorMessage"] = "Error from Provider";
				return RedirectToAction(nameof(Login));
			}

			//Checking to see if the web app supports that external login async. 
			var info = await _signInManager.GetExternalLoginInfoAsync();

			if (info == null)
			{
				return RedirectToAction(nameof(Login));
			}

			// sign the user in with the external login. See if the user has used this external login provider previously. 
			var result = await _signInManager.ExternalLoginSignInAsync
				(info.LoginProvider, info.ProviderKey,
				isPersistent: false, bypassTwoFactor: true);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}

			//get the email if this is the first time
			var email = info.Principal.FindFirstValue(ClaimTypes.Email);





			//redirect to the external login page for the user to 
			return View("ExternalLogin", new ExternalLoginViewModel { Email = email });


		}

		/// <summary>
		/// Capture the information if it is the first time the user has signed in with this external provider
		/// </summary>
		/// <param name="elvm">Email from the user</param>
		/// <returns>task of completion</returns>
		public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
		{
			if (ModelState.IsValid)
			{
				var info = await _signInManager.GetExternalLoginInfoAsync();
				if (info == null)
				{
					TempData["Error"] = "Error loading information";
				}

				//Create the user.
				//TODO: Could potentially force the user to add a password here....
				//
				var user = new ApplicationUser { UserName = elvm.Email, Email = elvm.Email };

				var result = await _userManager.CreateAsync(user);

				if (result.Succeeded)
				{
					//TODO: Potentially add Claims here.....

					result = await _userManager.AddLoginAsync(user, info);

					if (result.Succeeded)
					{
						// sign the user in with the information they gave us
						await _signInManager.SignInAsync(user, isPersistent: false);

						return RedirectToAction("Index", "Home");

					}
				}


			}
			return View(elvm);
		}
	}
}