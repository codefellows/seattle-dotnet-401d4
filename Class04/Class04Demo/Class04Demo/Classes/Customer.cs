using System;
using System.Collections.Generic;
using System.Text;

namespace Class04Demo.Classes
{
	class Customer
	{
		public string Name { get; set; } = "Amanda";

	//	private int _age = 21;

		public int Age { get; set; }



		public Customer(string name)
		{
			Name = name;
			//Console.WriteLine($"Hello {name}");
		}

		public Customer()
		{

		}
	}
}
