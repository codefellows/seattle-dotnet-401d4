using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass13.Data;
using DemoClass13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoClass13.Controllers
{
    public class AuthorController : Controller
    {
	    private DemoClass13DbContext _database;

	    public AuthorController(DemoClass13DbContext database)
	    {
		    _database = database;
	    }


	    public async Task<IActionResult> Index()
	    {
		    return View(await _database.Authors.ToListAsync());
	    }

		[HttpGet]
	    public IActionResult Create()
	    {
		    return View();
	    }

	    [HttpPost]
	    public async Task<IActionResult> Create([Bind("ID, Name, NumberOfBooks, HomeTown")]Author author)
	    {

		    _database.Authors.Add(author);
		    await _database.SaveChangesAsync();

		    int id = author.ID;
		    return View();
	    }

	    public  async Task<IActionResult> Delete(int id)
	    {
		    var author = await _database.Authors.FindAsync(id);
			

		    if (author == null)
		    {
			    return NotFound();
		    }

		

		    _database.Authors.Remove(author);
		    await _database.SaveChangesAsync();

		    return View();
	    }

		
	}
}
