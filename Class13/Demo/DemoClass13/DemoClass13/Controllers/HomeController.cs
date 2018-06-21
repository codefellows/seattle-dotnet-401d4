using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass13.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoClass13.Controllers
{
    public class HomeController : Controller
    {
	    private DemoClass13DbContext _database;

	    public HomeController(DemoClass13DbContext database)
	    {
		    _database = database;
	    }

	    public IActionResult Index()
	    {
		    return View();
	    }

    }
}
