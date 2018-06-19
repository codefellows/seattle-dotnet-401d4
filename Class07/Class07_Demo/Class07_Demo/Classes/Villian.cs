using System;
using System.Collections.Generic;
using System.Text;
using Class07_Demo.Interface;

namespace Class07_Demo.Classes
{
	class Villian : Person, IConquer, IPlay
	{
		public int NumberOfMinions { get; set; }
		public override bool HasFace { get; set; } = false;


		public string EvilLaugh()
		{
			return "Muwhaahahahahahha";
		}

		public string EvilPlot()
		{
			return "Take over the world!!!";
		}

		public string Monologue { get; set; }

		//Interface Method from IConquer Interface
		public string TragicBackstory(string hometown)
		{
			return "I grew up in North Dakota.";
		}

		//Abstract Method from Person Class
		public override string MyAbstractMethod()
		{
			return " Behold, Abstraction!";
		}

		//virtual method from Person class
		public override string MyVirtualMethod()
		{
			return "Hello";
		}

		public string HenchmanPet(string petName)
		{
			return "chihuaha";
		}

		public string Activity()
		{
			throw new NotImplementedException();
		}
	}
}
