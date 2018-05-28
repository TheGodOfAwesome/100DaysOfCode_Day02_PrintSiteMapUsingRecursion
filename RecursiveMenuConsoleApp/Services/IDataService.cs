using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RecursiveMenuConsoleApp.DAO;

namespace RecursiveMenuConsoleApp.Services
{
    public interface IDataService
    {
        List<MenuItem> GetAllMenuItems();
    }

    public class DataService : IDataService
    {
        public List<MenuItem> GetAllMenuItems()
        {
            var menuList = new List<MenuItem>();
            using (var connection =
                new SqlConnection("Server=KUZIVAKWASHE-PC\\SQLEXPRESS;Database=Learning;Integrated Security=True"))
            {
                Console.WriteLine("Id | " + "Link  | " + "Title | " + "ParentId | " +
                                  "Parent\n");
                connection.Open();
                var command = new SqlCommand("Select * From Menu", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new MenuItem();
                        item.Id = reader.GetInt32(0);
                        item.Title = reader.GetString(1);
                        item.Link = reader.GetString(2);
                        var parentIdSqlInt = reader.GetSqlInt32(3);
                        item.ParentId = parentIdSqlInt.IsNull ? (int?) null : parentIdSqlInt.Value;
                        var parentSqlString = reader.GetSqlString(4);
                        item.Parent = parentSqlString.ToString();
                        Console.WriteLine(item.Id + "| " + item.Link + " | " + item.Title + " | " + item.ParentId +
                                          " | " +
                                          item.Parent + "\n");
                        menuList.Add(item);
                    }
                }
            }
            return menuList;
        }
    }
}