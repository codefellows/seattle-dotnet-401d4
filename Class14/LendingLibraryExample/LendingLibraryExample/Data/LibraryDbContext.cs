using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendingLibraryExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace LendingLibraryExample.Data
{
    public class LibraryDbContext : DbContext
    {
	    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
	    {
		    
	    }

	    public DbSet<Author> Authors { get; set; }
	    public DbSet<Book> Books { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
			//modelBuilder.Entity<Post>().HasData(
			//	new { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" },
			//	new { BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2" });
		}
    }
}
