using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusMall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusMall.Controllers
{
	[Authorize(Policy = "CodefellowsOnly")]

	public class ClubhouseController : Controller
	{
		private IInventory _inventory;

		public ClubhouseController(IInventory inventory)
		{
			_inventory = inventory;
		}
		public IActionResult Index()
		{
			return View(_inventory.GetProducts());
		}
	}
}