using Cohort4ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Data
{
    public class CMSDbContext:DbContext
    {
		public CMSDbContext(DbContextOptions<CMSDbContext> options):base(options)
		{

		}

		public DbSet<Post> Posts { get; set; }
    }
}
