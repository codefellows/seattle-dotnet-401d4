using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPatternClass42.Classes
{
    public abstract class Pizza
    {
		public void Prepare()
		{
			Console.WriteLine("Preparing the Pizza");
		}

		public void Bake()
		{
			Console.WriteLine("Bake the Pizza");
		}

		public void Box()
		{
			Console.WriteLine("Box it up!");
		}

    }

}
