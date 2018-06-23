using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LendingLibraryExample.Models
{
    public class Book
    {
	    public int ID { get; set; }

		[Required]
	    public string Title { get; set; }
		[Required]
		[Display(Name="Year Published")]
		public int YearPublished { get; set; }
	    public Author Author { get; set; }
	    public int AuthorId { get; set; }
    }
}
