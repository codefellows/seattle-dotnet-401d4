using System;
using FactoryPatternClass42.Classes;

namespace FactoryPatternClass42
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			PizzaPlanetExample();
		}

		static void PizzaPlanetExample()
		{
			Pizza pizza = null;
			PizzaPlanet pizzaPlanet = new PizzaPlanet();
			pizza = pizzaPlanet.OrderPizza("falling with style");

		}

		//static void OrderPizza(string type)
		//{
		//	PizzaFactory pf = new PizzaFactory();
		//	Pizza pizza = pf.CreatePizza(type);

		//	pizza.Prepare();
		//	pizza.Bake();
		//	pizza.Box();


		//}
	}
}
