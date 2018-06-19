using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Class09Demo.Classes;
using Class05_LinkedList;

namespace Class09Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			CarExample();

			//LinqExample();

			LambdaExample();
		}

		static void CarExample()
		{
			Car car = new Car
			{
				Color = (Color)3,
				Manufacturer = "Willy Wonka",
				NumberOfDoors = 7,
				TopSpeed = 500
			};

			Garage<Car> myCars = new Garage<Car> { car };

			List<Car> myList = new List<Car>();

		}

		public static void LinqExample()
		{
			string[] myArray = { "Elsa", "Anna", "Sven", "Merida" };

			IEnumerable<string> myResults = from n in myArray
											where n.Length < 5
											select n;

			foreach (string name in myResults)
			{
				Console.WriteLine(name);
			}

			string[] myName = { "Wisps", "Elinor", "Candy", "Princess", "Castle" };

			Console.WriteLine("-Original Dataset-");
			Console.WriteLine("--------------");


			foreach (string thing in myName)
			{
				Console.WriteLine(thing);
			}

			var result = from i in myName
						 where i.Contains("i")
						 select i;

			Console.WriteLine("--------------");
			Console.WriteLine("-Modified Dataset-");
			Console.WriteLine("--------------");

			var max = "string";
			max = "5";
			int jermaine = Convert.ToInt32(max);

			foreach (string thing in result)
			{
				Console.WriteLine(thing);
			}

			IEnumerable<string> result2 = from n in result
										  where n.Length > 5
										  select n;


			Console.WriteLine("--------------");
			Console.WriteLine("-Filterd Result2 Dataset-");
			Console.WriteLine("--------------");


			foreach (string thing in result2)
			{
				Console.WriteLine(thing);
			}


		}

		public static void LambdaExample()
		{
			string[] students =
				{ "Jackie", "Amanda", "Jimmy", "Jermaine",
				"Jessie", "Rhiannon", "Eric", "Phil",
				"Cat", "Benjamin", "A", "Earl Jay" };

			var filteredStudents = students.Distinct()
											.OrderBy(n => n.Length);



			foreach (var name in filteredStudents)
			{
				Console.WriteLine(name);
			}

		}
	}
}
