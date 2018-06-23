using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass14.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoClass14.Data
{
    public class LibraryDbContext : DbContext
    {
	    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
			: base(options)
	    {
		    
	    }

	    public DbSet<Author> Authors { get; set; }
	    public DbSet<Book> Books { get; set; }
    }
}
