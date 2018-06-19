using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class11Demo.Models;
using Class11Demo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class11Demo.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index(string name, int number)
		{
			Cat cat = new Cat("Josie", 6, true);
			Cat cat2 = new Cat("Belle", 6, true);
			Cat cat3 = new Cat("Sox", 15, false);
			Cat cat4 = new Cat("Joey", 1, false);
			Cat cat5 = new Cat("Banks", 1, false);

			List<Cat> myCats =
				new List<Cat> { cat, cat2, cat3, cat4, cat5 };

			ViewData["CatGreeting"] = "This is my Cat Greeting";



			return View(cat);
		}

		[HttpPost]
		public IActionResult Index(Cat cat)
		{
			string name = cat.Name;
			return View();
		}


		public IActionResult TestExample(int number, bool myBool)
		{
			return RedirectToAction("ResponseExample", new {newNumber = number, newBool = myBool});
		}

		public IActionResult ResponseExample(int newNumber, bool newBool)
		{
			// Do something in here that will 
			// all me to send the data to the view

			ResponseExampleViewModel revm = new ResponseExampleViewModel();
			revm.Number = newNumber;
			revm.IsTrue = newBool;

			return View(revm);
		}
	}
}
