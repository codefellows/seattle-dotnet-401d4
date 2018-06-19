using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass12.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoClass12.Data
{
    public class DemoClass12DbContext : DbContext
    {
	    public DemoClass12DbContext(DbContextOptions<DemoClass12DbContext> options) : base(options)
	    {
		    
	    }

	    public DbSet<Book> Book { get; set; }
    }
}
