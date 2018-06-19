using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass12.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoClass12.Controllers
{
    public class HomeController: Controller
    {
	    private DemoClass12DbContext _context;

	    public HomeController(DemoClass12DbContext context)
	    {
		    _context = context;

	    }

	    public IActionResult Index()
	    {

		   var authors = _context.Book.Where(n => n.Author.Length > 4);
		    return View();
	    }
    }
}
