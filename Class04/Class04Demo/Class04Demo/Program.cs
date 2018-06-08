using System;
using Class04Demo.Classes;

namespace Class04Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			ClassExample();

		}

		static void ClassExample()
		{
			Customer customer1 = new Customer("Erik");

			Customer customer2 = new Customer()
			{
				Name = "Octokitty",
				Age = 21
			};

			Customer amanda = customer1;
			Console.WriteLine(amanda.Name);
			Console.WriteLine(customer1.Name);

			Console.WriteLine("-----");

			string name = customer1.Name;
			customer1.Name = "Amanda";

			Console.WriteLine(amanda.Name);
			Console.WriteLine(customer1.Name);

			Cat myCat = new Cat("Dusty", 20);

		 Console.WriteLine(myCat.MakesSound());


		}
	}
}
