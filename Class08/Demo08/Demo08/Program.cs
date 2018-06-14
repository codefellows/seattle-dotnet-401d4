using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			//Console.WriteLine((Day)1000);
	       // GenericExample();

	        NumberListExample();



        }

	    static void GenericExample()
	    {
		    List<string> princesses = new List<string>();

		    princesses.Add("Snow White");
		    princesses.Add("Cinderella");
		    princesses.Add("Repunzel");
		    princesses.Add("Elsa");
		    princesses.Add("Merida");
		    princesses.Add("Ariel");

		    foreach (string princess in princesses)
		    {
			    Console.WriteLine(princess);

		    }
		   string name = princesses[3];

			Console.WriteLine();
			Console.WriteLine(name);


		    List<string> princes = new List<string>
		    {
			    "Aladdin",
				"Rogers Nelson",
				"Charming",
				"Eric",
				"Harry",
				"Charles"
		    };

			foreach(var i in princes)
		    {
			 Console.WriteLine(i);   
		    }

		    princes.Remove("Eric");
			Console.WriteLine();
		    foreach (var i in princes)
		    {
			    Console.WriteLine(i);
		    }

		}

		public static void NumberListExample()
	    {
			NumberList<int> myNumberList = new NumberList<int>();

		    myNumberList.Add(4);
		    myNumberList.Add(8);
		    myNumberList.Add(15);
		    myNumberList.Add(16);
		    myNumberList.Add(23);
		    myNumberList.Add(42);

			//GetEnumerator was implemented
		    foreach (int number in myNumberList)
		    {
			    Console.WriteLine(number);
		    }

			NumberList<int> secondTry = new NumberList<int>
			{
				4,
				8,
				15,
				16,
				23,
				42
			};

		    IEnumerable<string> myEnumerable = new List<string>();



	    }
	}
}
