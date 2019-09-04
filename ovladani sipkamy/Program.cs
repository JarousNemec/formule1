using System;

namespace formule1
{
    internal static class Program
    {
        public static void Main(string[] args)

        {
            Console.Title = "Formule1";
            new SplashScreen();
            new Menu();
            Console.ReadKey();
        }
    }
}