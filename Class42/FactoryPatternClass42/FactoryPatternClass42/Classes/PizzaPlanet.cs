using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternClass42.Classes
{
	class PizzaPlanet : PizzaStore
	{
		protected override Pizza CreatePizza(string type)
		{
			Console.WriteLine("We are creating the Pizza");
			Console.WriteLine("Buzz Lightyear to the rescue!");
			return PizzaPlanetFactory.CreatePizza(type);
		}
	}
}
