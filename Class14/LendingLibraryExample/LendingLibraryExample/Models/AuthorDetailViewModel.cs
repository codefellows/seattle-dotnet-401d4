using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendingLibraryExample.Data;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryExample.Models
{
    public class AuthorDetailViewModel
    {
	    public IEnumerable<Book> Books { get; set; }
	    public Author Author { get; set; }

	    public static async Task<AuthorDetailViewModel> FromIDAsync(int id, LibraryDbContext context)
	    {
		    AuthorDetailViewModel advm = new AuthorDetailViewModel();

		    advm.Author =
			    await context.Authors.Where(c => c.ID == id).SingleAsync();

		    advm.Books =
			    await context.Books.Where(s => s.Author == advm.Author)
				    .Select(s => s)
				    .ToListAsync();

		    return advm;
	    }
	}
}
