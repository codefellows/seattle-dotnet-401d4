using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendingLibraryExample.Data;
using LendingLibraryExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryExample.Controllers
{

    public class BookController : Controller
    {
	    private LibraryDbContext _context;

	    public BookController(LibraryDbContext context)
	    {
		    _context = context;
	    }

	    public async Task<IActionResult> Create()
	    {
			//Send the list of authors as a ViewDataList
			// Lok at the .cshtml file for the drop down on how this is being transferred over
		    ViewData["Authors"] = await _context.Authors.Select(c => c)
			    .ToListAsync();
			return View();
	    }


	    [HttpPost]
	    public async Task<IActionResult> Create([Bind("ID, Title, YearPublished, AuthorId")]Book book)
	    {
			//Get a single book
		    book.Author = await _context.Authors.Where(c => c.ID == book.AuthorId).SingleAsync();

			_context.Books.Add(book);
		    await _context.SaveChangesAsync();
		    return RedirectToAction("Index", "Home");
	    }

		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{
				//Get all the details of a book, inlcuding the author deets
				return View(await _context.Books.Where(s => s.ID == id)
					.Include(s => s.Author)
					.SingleAsync());
			}
			return View();

		}

	    public async Task<IActionResult> ViewAll()
	    {
		    var dta = await _context.Books.Include(s => s.Author).ToListAsync();

		    return View(dta);

	    }

		public IActionResult Edit()
	    {
		    return View();
	    }

	    public IActionResult Delete()
	    {
		    return View();
	    }
	}
}