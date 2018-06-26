using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass14.Data;
using DemoClass14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoClass14.Controllers
{
	public class AuthorController : Controller
	{
		private LibraryDbContext _context;

		public AuthorController(LibraryDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewData["Message"] = "Create an Author";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Author author)
		{
			await _context.Authors.AddAsync(author);
			await _context.SaveChangesAsync();

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int? id)
		{
			if (id.HasValue)
			{
				Author author = await _context.Authors.FirstOrDefaultAsync(a => a.ID == id);
				return View(author);
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Update([Bind("ID, Name, Genre")]Author author)
		{
			// Bring in the new values of the author object

			// Update the Database with the new data
			_context.Authors.Update(author);

			// Save the Db
			await _context.SaveChangesAsync();
			
			// Be Happy.

			return View(author);
		}


	}
}