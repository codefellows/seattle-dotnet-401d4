using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternClass42.Classes
{
    class PizzaPlanetFactory
    {
		public static Pizza CreatePizza(string pizzaType)
		{
			Console.WriteLine($"Creation of Pizza {pizzaType}");
			Pizza pizza = null;
			switch (pizzaType.ToLower())
			{
				case "galactic cheese":
					pizza = new Cheese();
					break;
				case "falling with style":
					pizza = new Hawaiian();
					break;
				default:
					break;
			}

			return pizza;

		}
	}
}
