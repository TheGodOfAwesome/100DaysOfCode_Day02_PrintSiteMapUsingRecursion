using System.Collections.Generic;

namespace RecursiveMenuConsoleApp.Models
{
    public class NavItemSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public List<int> Children { get; set; }
    }
}
