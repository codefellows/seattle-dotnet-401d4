using System;
using Class07_Demo.Classes;
using Class07_Demo.Interface;

namespace Class07_Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			InterfaceExample();
		}

		public static void InterfaceExample()
		{
			Villian villian = new Villian
			{
				HasFace = false,
				NumberOfMinions = 17,
				HairColor = "Pink",
				Name = "OctoCat",
				Age = 2
			};

			BendingUnit bender = new BendingUnit
			{
				Name = "Bender",
				InsertGirder = true,
				NumberOfLight = 5
			};

			Cat cat = new Cat
			{
				Age = 7,
				Name = "Josie",
				Monologue = "Meow meow meow"
			};

			Student student = new Student();
			student.Name = "Rhiannon";

			Student student2 = new Student();
			student2.Name = "Jermaine";

			Villian jackie = new Villian();
			jackie.Name = "Jackie";
			jackie.HasFace = false;

			Villian max = new Villian();
			max.Name = "Mad Max";
			max.HasFace = true;

			IConquer ic = bender;

			Person[] myPeeps = {student, student2, jackie, max};


			for (int i = 0; i < myPeeps.Length; i++)
			{
				if (myPeeps[i] is IConquer)
				{
					Console.WriteLine(myPeeps[i].Name);
				}
			}

		}
	}
}
