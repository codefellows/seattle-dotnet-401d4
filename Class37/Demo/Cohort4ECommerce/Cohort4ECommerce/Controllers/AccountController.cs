using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
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

		[AllowAnonymous]
		public async Task<IActionResult> AuthNetExample()
		{
	
			// Declare that you are using a sandbox acocunt
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = 
				AuthorizeNet.Environment.SANDBOX;

			// define the merchant information (authentication / transaction id)

			ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = 
				new merchantAuthenticationType()
			{
				name = "3Q36ttuxXa",
				ItemElementName = ItemChoiceType.transactionKey,
				Item = "22W45fGHPs6S42aZ",
			};


			var creditCard = new creditCardType
			{
				cardNumber = "4111111111111111",
				expirationDate = "0718"
			};

			var billingAddress = new customerAddressType
			{
				firstName = "John",
				lastName = "Doe",
				address = "123 My St",
				city = "OurTown",
				zip = "98004"
			};

			//standard api call to retrieve response
			var paymentType = new paymentType { Item = creditCard };

			var lineItems = new lineItemType[2];
			lineItems[0] = new lineItemType { itemId = "1", name = "t-shirt",
				quantity = 2, unitPrice = new Decimal(15.00) };
			lineItems[1] = new lineItemType { itemId = "2", name = "snowboard",
				quantity = 1, unitPrice = new Decimal(450.00) };


			var transactionRequest = new transactionRequestType
			{
				transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),   // charge the card
				amount = 10.00m,
				payment = paymentType,
				billTo = billingAddress
			};

			var request = new createTransactionRequest { transactionRequest = transactionRequest };

			// instantiate the contoller that will call the service
			var controller = new createTransactionController(request);
			controller.Execute();

			// get the response from the service (errors contained if any)
			var response = controller.GetApiResponse();

			if (response != null)
			{
				if (response.messages.resultCode == messageTypeEnum.Ok)
				{
					if (response.transactionResponse.messages != null)
					{
						Console.WriteLine("Successfully created transaction with Transaction ID: " 
							+ response.transactionResponse.transId);
						Console.WriteLine("Response Code: " + 
							response.transactionResponse.responseCode);
						Console.WriteLine("Message Code: " + 
							response.transactionResponse.messages[0].code);
						Console.WriteLine("Description: " + 
							response.transactionResponse.messages[0].description);
						Console.WriteLine("Success, Auth Code : " + 
							response.transactionResponse.authCode);
					}
					else
					{
						Console.WriteLine("Failed Transaction.");
						if (response.transactionResponse.errors != null)
						{
							Console.WriteLine("Error Code: " + 
								response.transactionResponse.errors[0].errorCode);
							Console.WriteLine("Error message: " + 
								response.transactionResponse.errors[0].errorText);
						}
					}
				}
				else
				{
					Console.WriteLine("Failed Transaction.");

					if (response.transactionResponse != null && 
						response.transactionResponse.errors != null)
					{
						Console.WriteLine("Error Code: " + 
							response.transactionResponse.errors[0].errorCode);
						Console.WriteLine("Error message: " + 
							response.transactionResponse.errors[0].errorText);
					}
					else
					{
						Console.WriteLine("Error Code: " + response.messages.message[0].code);
						Console.WriteLine("Error message: " + response.messages.message[0].text);
					}
				}
			}
			else
			{
				Console.WriteLine("Null Response.");
			}

			return View();
		}
	}
}