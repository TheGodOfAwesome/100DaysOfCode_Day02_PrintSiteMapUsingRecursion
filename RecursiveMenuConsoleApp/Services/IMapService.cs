using System.Collections.Generic;
using RecursiveMenuConsoleApp.DAO;
using RecursiveMenuConsoleApp.Models;

namespace RecursiveMenuConsoleApp.Services
{
    public interface IMapService
    {
        List<int> MapNavTree(List<MenuItem> navItems, int? parentId, int childId);
        SiteMap NavSummary(List<MenuItem> navItems, int itemId);
    }

    public class MapService : IMapService
    {
        public MapService()
        {
        }
        
        public List<int> MapNavTree(List<MenuItem> navItems, int? parentId, int childId)
        {
            List<int> navPath = new List<int>();
            navPath.Add(childId);
            while (parentId != null)
            {
                int? idCheck = parentId;
                foreach (var navItem in navItems)
                {
                    if (navItem.Id == parentId)
                    {
                        navPath.Add(navItem.Id);
                        parentId = navItem.ParentId;
                    }
                }
                if (idCheck == parentId)
                    parentId = null;
            }
            return navPath;
        }

        public SiteMap NavSummary(List<MenuItem> navItems, int itemId)
        {
            var siteMapItem = new SiteMap();
            foreach (var navItem in navItems)
            {
                if (navItem.Id == itemId)
                {
                    siteMapItem.Id = navItem.Id;
                    siteMapItem.Title = navItem.Title;
                    siteMapItem.Link = navItem.Link;
                    siteMapItem.Children = MapChildren(navItems, itemId);
                }
            }
            return siteMapItem;
        }

        private List<NavItem> MapChildren(List<MenuItem> menuItems, int? id)
        {
            var children = new List<NavItem>();
            while (id != null)
            {
                var idCheck = id;
                foreach (var menuItem in menuItems)
                {
                    if (menuItem.ParentId == id)
                    {
                        NavItem navItem = new NavItem
                        {
                            Id = menuItem.Id,
                            Title = menuItem.Title,
                            Link = menuItem.Link
                        };
                        children.Add(navItem);
                        children = MapGrandChildren(menuItems, navItem.Id, children);
                        id = menuItem.ParentId;
                    }
                }
                if (idCheck == id)
                    id = null;
            }
            return children;
        }

        private List<NavItem> MapGrandChildren(List<MenuItem> menuItems, int? id, List<NavItem> children)
        {
            while (id != null)
            {
                var idCheck = id;
                foreach (var menuItem in menuItems)
                {
                    if (menuItem.ParentId == id)
                    {
                        NavItem navItem = new NavItem
                        {
                            Id = menuItem.Id,
                            Title = menuItem.Title,
                            Link = menuItem.Link
                        };
                        children.Add(navItem);
                        id = menuItem.ParentId;
                    }
                }
                if (idCheck == id)
                    id = null;
            }
            return children;
        }
    }
}
