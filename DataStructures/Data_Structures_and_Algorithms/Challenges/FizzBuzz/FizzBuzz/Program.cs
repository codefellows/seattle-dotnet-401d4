using System;


namespace FizzBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Method call with the integer 20 as an argument
            FizzBuzz(20);
        }

        public static string FizzBuzz(int n)
        {
            //loop to iterate through through then numbers
            for (int i = 0; i < n; i++)
            {
                // if divisible by 3 and 5 output "FizzBuzz" to console
                if (i % 3 == 0 && i % 5 == 0)
                {
                    return "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    // If divisible only by 3 output "Fizz" to console
                    return "Fizz";

                }
                else if (i % 5 == 0)
                {
                    // If divisible only by 5 output "Buzz" to console
                    return "Buzz";

                }

            }

            return n.ToString();
        }
    }
}
