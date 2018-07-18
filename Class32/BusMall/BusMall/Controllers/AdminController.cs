using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusMall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusMall.Controllers
{
	[Authorize(Policy ="AdminOnly")]
    public class AdminController : Controller
    {
		private IInventory _inventory;

		public AdminController(IInventory inventory)
		{
			_inventory = inventory;
		}
        public IActionResult Index()
        {
            return View(_inventory.GetProducts());
        }


    }
}