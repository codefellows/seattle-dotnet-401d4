using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cohort4ECommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cohort4ECommerce.Models
{
	public class DevCMSRepo : ICMSRepo
	{
		private  CMSDbContext _context;

		public DevCMSRepo(CMSDbContext context)
		{
			_context = context;
		}

		public Task<IActionResult> CreatePost(Post post)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> DeletePost(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> GetPostById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> GetPosts()
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> UpdatePost(int id, Post post)
		{
			throw new NotImplementedException();
		}
	}
}
