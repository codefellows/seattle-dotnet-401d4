using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass13.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoClass13.Data
{
    public class DemoClass13DbContext : DbContext
    {
	    public DemoClass13DbContext(DbContextOptions<DemoClass13DbContext> options) : base(options)
	    {
		    
	    }

		public DbSet<Author> Authors { get; set; }

    }
}
