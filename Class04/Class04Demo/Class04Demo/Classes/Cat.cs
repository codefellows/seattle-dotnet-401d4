using System;
using System.Collections.Generic;
using System.Text;

namespace Class04Demo.Classes
{
    class Cat
    {
	    public string Name { get; set; }
	    public int Age { get; set; }
	    public string Sound { get; set; }

	    public Cat(string name, int age)
	    {
		    Name = name;
		    Age = age;
	    }

	    public string MakesSound()
	    {
		    string sound = Sound;
		    return sound;
	    }
    }
}
