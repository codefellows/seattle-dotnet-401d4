using System;

namespace Class01Demo
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello World!");
            Console.WriteLine("What is your fav color");
            // Asking the user for their favorite color from console
            string color = Console.ReadLine();
            //External method call and sending it what the user inputted
            FavoriteColor(color);
            Console.WriteLine(FavoriteCat());

            //Creating an array with an initializer
            int[] myArray = new int[]{4, 8, 15, 16, 23, 42};
            myArray[1] = 34;

        }
        
        static string FavoriteCat()
        {
            return "Miss Kitty Gitty Enum";
        }

        static void FavoriteColor(string color)
        {
            Console.WriteLine($"Your favorite color is {color}");

        }

    }
}
