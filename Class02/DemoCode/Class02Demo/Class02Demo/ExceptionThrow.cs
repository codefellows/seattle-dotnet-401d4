using System;
using System.Collections.Generic;
using System.Text;

namespace Class02Demo
{
	static class ExceptionThrow
	{
		//Output: 
		// Trying in Main() Method
		// Trying in Method A
		// Trying in Method B
		// In Method C
		// Caught in Method B
		// Caught in Method A
		// Caught in Main() method -- 
		// This came from Method C
		// Main() Method is done.


		// if we were to override the error, the old error is lost (unless handled)
		// and the new error is handled moving forward


		public static void MyMain()
		{
			//Main calls Method A
			try
			{
				Console.WriteLine("Trying in Main");
				MethodA();
			}
			catch (Exception ae)
			{
				Console.WriteLine($"Caught in Main Method {ae.Message}");
			}

			Console.WriteLine("Main() Method is done");

		}
		public static void MethodA()
		{
			//Method A Calls Method B
			try
			{
				Console.WriteLine("Trying in Method A");
				MethodB();
			}
			catch (Exception e)
			{
				Console.WriteLine("Caught in Method A");
				throw;

			}

			Console.WriteLine("Method A is done");

		}
		public static void MethodB()
		{
			//Method B Calls Method C
			try
			{
				Console.WriteLine("Trying in Method B");
				MethodC();
			}
			catch (Exception)
			{
				Console.WriteLine("Caught in Method B");
				throw;
			}

			Console.WriteLine("Method B is done");
		}
		public static void MethodC()
		{
			// Method C throws an exception...
			Console.WriteLine("I'm in Method C");
			throw (new Exception("this came from method C"));
		}

		//When Method B catches the Exception, it dies ont handle the exception, instead it just throws 
		// the exception on back to Method A

		// Method A catches the exception but does not handle it. Instead, A throws it to Main

		// Exeption is caught in Main and Method C's message is finally displayed. 
	}
}
