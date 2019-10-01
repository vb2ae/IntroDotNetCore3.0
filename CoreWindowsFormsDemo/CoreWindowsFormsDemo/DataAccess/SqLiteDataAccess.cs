using CoreWindowsFormsDemo.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace CoreWindowsFormsDemo.DataAccess
{
    public class SqLiteDataAccess
    {
       private const string Path = "Products.db";
       public void EnsureDatabaseIsCreated()
        {
            if (!File.Exists(Path))
            {
                using(FileStream fs = new FileStream(Path, FileMode.Create))
                {
                    fs.Flush();
                }
                CreateDB();
            }
        }

        private void CreateDB()
        {
            string connectionString = $"Data Source={Path}";
            using SqliteConnection conn = new SqliteConnection(connectionString);

            conn.Open();
            SqliteCommand cmd = new SqliteCommand("CREATE TABLE Products(ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                        " Name CHAR(50) NOT NULL,Price Float NOT NULL);", conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Insert into Products (Name, Price) Values ('Chai', 18.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Chang', 19.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Aniseed Syrup', 10.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Chef Antons Cajun Seasoning', 22.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Chef Antons Gumbo Mix', 21.35)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Grandmas Boysenberry Spread', 25.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Uncle Bobs Organic Dried Pears', 30.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Northwoods Cranberry Sauce', 40.0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Products (Name, Price) Values ('Mishi Kobe Niku', 97.0)";
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public ObservableCollection<Product> GetDataFromDB()
        {
            string connectionString = $"Data Source={Path}";
            using SqliteConnection conn = new SqliteConnection(connectionString);

            ObservableCollection<Product> products = new ObservableCollection<Product>();
            SqliteCommand getData = new SqliteCommand("Select * from products", conn);
            conn.Open();
            var reader = getData.ExecuteReader();
            while (reader.Read())
            {
                int id = 0;
                int.TryParse(reader[0].ToString(), out id);

                decimal price = 0.0m;
                decimal.TryParse(reader[2].ToString(), out price);
                products.Add(new Product()
                {
                    Id = id,
                    Name = reader[1].ToString(),
                    Price = price

                });
            }

            return products;
        }
    }
}
