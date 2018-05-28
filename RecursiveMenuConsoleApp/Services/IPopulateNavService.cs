using System;
using System.Collections.Generic;
using RecursiveMenuConsoleApp.DAO;
using RecursiveMenuConsoleApp.Models;

namespace RecursiveMenuConsoleApp.Services
{
    public interface IPopulateNavService
    {
        List<SiteMap> RecurseThroughMenu(List<MenuItem> menuItems, int position);
    }

    public class PopulateNav : IPopulateNavService
    {
        MapService map = new MapService();
        public List<string> navList = new List<string>();
        public List<List<int>> navMap = new List<List<int>>();
        public List<SiteMap> navSummary = new List<SiteMap>();

        public PopulateNav()
        {
        }

        public List<SiteMap> RecurseThroughMenu(List<MenuItem> menuItems, int parentId)
        {
            if (parentId < menuItems.Count + 1)
            {
                string parent = menuItems[parentId - 1].Title.ToString();
                if (!navList.Contains(parent))
                {
                    navList.Add(parent);
                    navSummary.Add(map.NavSummary(menuItems, parentId));
                    Console.WriteLine(parent);
                }
                PrintResults(menuItems, parentId);
                if (menuItems[parentId - 1].ParentId == null)
                    RecurseThroughMenu(menuItems, ++parentId);
            }
            return navSummary;
        }

        private void PrintResults(List<MenuItem> menuItems, int parentId)
        {
            foreach (var menuItem in menuItems)
            {
                if (parentId == menuItem.ParentId && !navList.Contains(menuItem.Title))
                {
                    NavItem navItem = new NavItem();
                    navItem.Id = menuItem.Id;
                    navItem.Title = menuItem.Title;
                    navItem.Link = menuItem.Link;
                    navSummary.Add(map.NavSummary(menuItems, navItem.Id));
                    var navPath = map.MapNavTree(menuItems, parentId, navItem.Id);
                    navMap.Add(navPath);
                    Console.WriteLine((new string('\t', navPath.Count - 2)) + "--->" + navItem.Title);
                    navList.Add(navItem.Title);
                    RecurseThroughMenu(menuItems, menuItem.Id);
                }
            }
        }
    }
}
