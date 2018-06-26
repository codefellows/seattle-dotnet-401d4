using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LendingLibraryExample.Models
{
	public class Author
	{
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public Genre Genre { get; set; }

	}

	public enum Genre
	{
		[Display(Name = "Science Fiction")] ScienceFiction,
		Romance,
		Mystery,
		Comics,
		History,
		Fantasy
	}
}
