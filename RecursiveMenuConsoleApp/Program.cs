using System;
using RecursiveMenuConsoleApp.Services;

namespace RecursiveMenuConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateNav nav = new PopulateNav();
            DataService data = new DataService();
            Console.WriteLine("\n");
            nav.RecurseThroughMenu(data.GetAllMenuItems(), 1);
        }
    }
}