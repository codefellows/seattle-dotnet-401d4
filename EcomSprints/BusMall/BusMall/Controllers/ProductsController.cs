using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusMall.Data;
using BusMall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusMall.Controllers
{
	[Authorize(Policy = "AdminOnly")]
	public class ProductsController : Controller
	{
		private readonly IInventory _context;

		public ProductsController(IInventory context)
		{
			_context = context;

		}

		// GET: Products
		[HttpGet("/admin/products")]
		public async Task<IActionResult> Index()
		{
			return View(_context.GetProducts());
		}

		[HttpGet("/admin/products/Details")]
		// GET: Products/Details/5
		public async Task<IActionResult> Details(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			Product product = _context.GetProductById(id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Create
		[HttpGet("/admin/products/Create")]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Products/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost("/admin/products/Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,SKU,Name,Price,Quantity,Description,Image,Thumbnail")] Product product)
		{
			if (ModelState.IsValid)
			{
				_context.CreateProduct(product);
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

		// GET: Products/Edit/5
		[HttpGet("/admin/products/Edit")]
		public async Task<IActionResult> Edit(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}

			var product = _context.GetProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost("/admin/products/Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,SKU,Name,Price,Quantity,Description,Image,Thumbnail")] Product product)
		{
			if (id != product.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.UpdateProduct(product);

				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(product.ID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index", "Admin");
			}
			return View(product);
		}

		// GET: Products/Delete/5
		[HttpGet("/admin/products/Delete")]

		public async Task<IActionResult> Delete(int id)
		{
			var product = _context.GetProductById(id);
			_context.DeleteProduct(product.ID);
			return RedirectToAction("Index", "Admin");
		}



		private bool ProductExists(int id)
		{
			var product = _context.GetProductById(id);

			if (product == null)
			{
				return false;
			}
			return true;
		}
	}
}