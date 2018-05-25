using System;
using System.Collections.Generic;
using RecursiveMenuConsoleApp.DAO;
using RecursiveMenuConsoleApp.Models;

namespace RecursiveMenuConsoleApp.Services
{
    public interface IPopulateNavService
    {
        void RecurseThroughMenu(List<MenuItem> menuItems, int position);
    }

    public class PopulateNav : IPopulateNavService
    {
        public PopulateNav()
        {
        }

        public void RecurseThroughMenu(List<MenuItem> menuItems, int parentId)
        {
            if (parentId < menuItems.Count + 1)
            {

                string parent = menuItems[parentId - 1].Title.ToString();
                Console.WriteLine("--------------\n" + parent);
                PrintResults(menuItems, parentId);
                if(menuItems[parentId - 1].ParentId == null)
                    RecurseThroughMenu(menuItems, ++parentId);
            }
        }

        private void PrintResults(List<MenuItem> menuItems, int parentId)
        {
            foreach (var menuItem in menuItems)
            {
                if (parentId == menuItem.ParentId)
                {
                    NavItem navItem = new NavItem();
                    navItem.Id = menuItem.Id;
                    navItem.Title = menuItem.Title;
                    navItem.Link = menuItem.Link;
                    Console.WriteLine(navItem.Title);
                    RecurseThroughMenu(menuItems, menuItem.Id);
                }
            }
        }
    }
}
