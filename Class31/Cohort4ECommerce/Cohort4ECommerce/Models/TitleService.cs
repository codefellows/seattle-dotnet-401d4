using Cohort4ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Models
{
	public class TitleService : ITitleService
	{
		private CMSDbContext _context;

		public TitleService(CMSDbContext context)
		{
			_context = context;
		}
		public List<Post> GetTopTitles(int number)
		{
			return _context.Posts.OrderByDescending(a => a.ID).Take(number).ToList();

		}
	}
}
