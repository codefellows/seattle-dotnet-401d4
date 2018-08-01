using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternClass42.Classes
{
	public class PizzaFactory
	{

		public Pizza CreatePizza(string pizzaType)
		{
			Pizza pizza = null;
			switch (pizzaType.ToLower())
			{
				case "cheese":
					pizza = new Cheese();
					break;
				case "hawaiian":
					pizza = new Hawaiian();
					break;
				default:
					break;
			}

			return pizza;

		}
	}
}
