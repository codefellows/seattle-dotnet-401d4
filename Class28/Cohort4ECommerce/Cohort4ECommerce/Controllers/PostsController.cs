﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cohort4ECommerce.Controllers
{
	[Authorize]
    public class PostsController : Controller
    {
		
        public IActionResult Index()
        {
            return View();
        }
    }
}