using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


		// TIME: O(N*M)
			// n = length of paylod
			// m - length of source
		// SPACE: 
		// assuming both are the same length and very very large....
			// with StringBuilder:  O(N^2)
			// w.o SB: O(n^4)
				// a + aa + aaa + + aaaa + etc... 
		protected string replaceCharacters(string payload, string source, string target)
		{
			string result = "";
			for (int i = 0; i < payload.Length; i++)
			{
				for (int j = 0; j < source.Length; j++)
				{
					if (payload[i] == source[j])
					{
						result += target[j];
					}
				}
			}
			return result;
		}


		// Time: O(n) iterating through the array right away
		// Space: O(n) becaues of the array conversion
		protected string ReplaceCharacters(string payload, string source, string target)
		{
			String result = "";
			char[] array = payload.ToCharArray();
			foreach (char cc in array)
			{
				int index = source.IndexOf(cc); //< --Hidden for loop-- > increases O(n)..O(n ^ 2)

				if (index >= 0)
				{
					result += target[index]; // o(1) since we know the index
				}
				else
				{
					result += cc; //< --Since not SB, space increases to: O(p ^ 2) p == paylod time.
								//Space: O(p ^ 2) 
								// Time: O(n ^ 2)

				}
			}
		
			return result;
		}

	}
}
