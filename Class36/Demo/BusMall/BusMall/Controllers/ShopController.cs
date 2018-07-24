using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusMall.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusMall.Controllers
{
    public class ShopController : Controller
    {
		private IInventory _inventory;

		public ShopController(IInventory inventory)
		{
			_inventory = inventory;

		}
        public IActionResult Index()
        {
            return View(_inventory.GetProducts());
        }

		public IActionResult Details(int id) => View(_inventory.GetProductById(id));
	}
}