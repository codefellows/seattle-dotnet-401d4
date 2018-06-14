using System;
using System.Collections.Generic;
using System.Text;

namespace Class07_Demo.Classes
{
	abstract class Robot
	{
		public int NumberOfLight { get; set; }
		public string Name { get; set; }

		public string Dreams()
		{
			return "I wanna be Human!";
		}

		public bool Lasers()
		{
			return true;
		}
	}
}
