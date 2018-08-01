using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternClass42.Classes
{
	public abstract class PizzaStore
	{
		//public PizzaFactory factory { get; set; }

		protected abstract Pizza CreatePizza(string type);
		public Pizza OrderPizza(string type)
		{
			Pizza pizza = CreatePizza(type);

			pizza.Prepare();
			pizza.Bake();
			pizza.Box();

			return pizza;
		}
	}
}
