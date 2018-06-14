using System;
using System.Collections.Generic;
using System.Text;

namespace Class09Demo.Classes
{
    class Car
    {
	    public int NumberOfDoors { get; set; }
	    public int TopSpeed { get; set; }
	    public string Manufacturer { get; set; }

	    public Color Color { get; set; }

    }

	enum Color
	{
		Red,
		Green,
		Blue,
		Purple,
		Black,
		Yellow,
		Shiny
	}
}
