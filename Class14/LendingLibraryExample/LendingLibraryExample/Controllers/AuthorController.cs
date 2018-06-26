using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendingLibraryExample.Data;
using LendingLibraryExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LendingLibraryExample.Controllers
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

		/// <summary>
		/// Initial load/get of the create page.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// Create an author from server postback
		/// </summary>
		/// <param name="author">Author object that is created from user input</param>
		/// <returns>send to the Create page.</returns>
		[HttpPost]
		public async Task<IActionResult> Create([Bind("ID, Name, Genre")]Author author)
		{

			await _context.Authors.AddAsync(author);
			await _context.SaveChangesAsync();

			int id = author.ID;
			return View();
		}

		/// <summary>
		/// View the information about the individual Author
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{
				return View(await AuthorDetailViewModel.FromIDAsync(id.Value, _context));
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		public async Task<IActionResult> ViewAll()
		{
			var dta = await _context.Authors.ToListAsync();

			return View(dta);

		}


		/// <summary>
		/// Delete an Author from the system. 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> Delete(int id)
		{
			var author = await _context.Authors.FindAsync(id);


			if (author == null)
			{
				return NotFound();
			}

			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();

			return View();
		}



	}
}