using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cohort4ECommerce.Models;

namespace Cohort4ECommerce.Components
{
    public class TopTitles: ViewComponent
	{
		private ITitleService _titles;

		public TopTitles(ITitleService titles)
		{
			_titles = titles;
		}

		public IViewComponentResult Invoke(int number)
		{
			var postTitles= _titles.GetTopTitles(number);

			return View(postTitles);
		}
    }
}
