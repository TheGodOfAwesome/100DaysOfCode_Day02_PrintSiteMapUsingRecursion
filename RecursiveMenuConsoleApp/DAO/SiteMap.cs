using System.Collections.Generic;
using RecursiveMenuConsoleApp.Models;

namespace RecursiveMenuConsoleApp.DAO
{
    public class SiteMap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public List<NavItem> Children { get; set; }
    }
}
