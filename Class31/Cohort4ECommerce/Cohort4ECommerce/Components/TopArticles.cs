using Cohort4ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Components
{
    public class TopArticles : ViewComponent
    {
		private CMSDbContext _context;

		public TopArticles(CMSDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync(int number)
		{
			var posts = _context.Posts.OrderByDescending(a => a.ID).Take(number).ToList();

			return View(posts);
		}
    }
}
