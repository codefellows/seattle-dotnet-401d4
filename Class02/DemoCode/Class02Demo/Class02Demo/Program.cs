using System;

namespace Class02Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Hello World!");
				//TryBlockExample();
				CatchSingleException();
			}
			catch (Exception e)
			{
				Console.WriteLine("This is Main");
				Console.WriteLine(e.Message);
			}

		}

		static void TryBlockExample()
		{
			string number = "twenty";
			
			try
			{
				int twenty = Convert.ToInt32(number);
			}
			//catch (FormatException t)
			//{
			//	Console.WriteLine($"{number} is not an integer");
			//	Console.WriteLine(t.Message);

			//}
			//catch (NullReferenceException ex)
			//{
			//	Console.WriteLine("This is an exception for Null references");
			//}
			catch (Exception ex)
			{
				Console.WriteLine("This is an exception");
				Console.WriteLine(ex.Message);
			}
		}

		static void CatchSingleException()
		{
			int milesDriven, gallonsOfGas, mpg;

			try
			{
				Console.WriteLine("Enter Miles Driven: ");
				milesDriven = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine("Enter gallons of gas purchased: ");
				gallonsOfGas = Convert.ToInt32(Console.ReadLine());

				mpg = milesDriven / gallonsOfGas;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error from the CatchSingleException Method");
				throw;
			}
			finally
			{
				Console.WriteLine("This is executed Last");
			}

			Console.WriteLine("Hello Earl Jay!");



		}
	}
}
