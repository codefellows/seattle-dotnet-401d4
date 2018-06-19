using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Class11Demo.Models
{
    public class Cat
    {
	    public string Name { get; set; }
	    public int Age { get; set; }
	    public bool IsFat { get; set; }


	    public Cat(string name, int age, bool isFat)
	    {
		    Name = name;
		    Age = age;
			IsFat = isFat;
	    }

	    public Cat()
	    {
		    
	    }
    }
}
