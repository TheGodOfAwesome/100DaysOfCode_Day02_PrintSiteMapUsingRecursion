using System;
using System.Collections.Generic;
using RecursiveMenuConsoleApp.DAO;
using RecursiveMenuConsoleApp.Models;

namespace RecursiveMenuConsoleApp.Services
{
    public interface IBuildNavService
    {
        void PrintMenu();
    }

    public class BuildNav : IBuildNavService
    {
        public BuildNav()
        {
        }

        public void PrintMenu()
        {
            List<List<NavItem>> nav = GetMenu();
            foreach (List<NavItem> list in nav)
            {
                foreach (NavItem item in list)
                {
                    Console.WriteLine(item.Id + ", " + item.Link + ", " + item.Title);
                }
            }
        }

        private List<List<NavItem>> GetMenu()
        {
            List<List<NavItem>> nav = new List<List<NavItem>>();
            DataService dataService = new DataService();
            var menuList = dataService.GetAllMenuItems();
            
            foreach (var menuItem in menuList)
            {
                int index = menuItem.Id;
                foreach (var item in menuList)
                {
                    NavItem navItem = new NavItem();
                    navItem.Id = item.Id;
                    navItem.Title = item.Title;
                    navItem.Link = item.Link;

                    List<NavItem> navList = new List<NavItem>();
                    navList.Add(navItem);
                    nav.Add(navList);
                }
            }
            return nav;
        }

        private List<NavItem> navFamily(List<MenuItem> menuList, int parentId)
        {
            List<NavItem> navList = new List<NavItem>();

            foreach (var menuItem in menuList)
            {
                if(parentId == menuItem.ParentId) { 
                    NavItem navItem = new NavItem();
                    navItem.Id = menuItem.Id;
                    navItem.Title = menuItem.Title;
                    navItem.Link = menuItem.Link;
                    navList.Add(navItem);
                }
            }
            return navList;
        }
    }
}
