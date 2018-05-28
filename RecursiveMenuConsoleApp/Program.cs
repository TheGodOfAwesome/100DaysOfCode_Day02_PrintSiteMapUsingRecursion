using System.IO;
using Newtonsoft.Json;
using RecursiveMenuConsoleApp.Services;

namespace RecursiveMenuConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateNav nav = new PopulateNav();
            DataService data = new DataService();
            var navSummary = nav.RecurseThroughMenu(data.GetAllMenuItems(), 1);
            File.WriteAllText(@"C:\Dev\RecursiveMenuConsoleApp\SiteMap\sitemap.json", JsonConvert.SerializeObject(navSummary));
        }
    }
}