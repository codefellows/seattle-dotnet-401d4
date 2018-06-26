using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoClass14.Models
{
    public class Book
    {
	    public int ID { get; set; }
		[Required]
	    public string Title { get; set; }
		[Required]
	    public Author Author { get; set; }
		[Required]
		[Display(Name="Number Of Pages")]
	    public int NumberOfPages { get; set; }
	 
    }
}
