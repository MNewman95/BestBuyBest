using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        { 
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepositoryClass(conn);
            Console.WriteLine("Type a new Department name");
            Console.WriteLine();
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);
            var departments = repo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            var product = new DapperDepartmentRepositoryClass(conn);
            Console.WriteLine("Type A new product name");
            Console.WriteLine();
            var newProduct = Console.ReadLine();
            Console.WriteLine("Now type the products price in this format '00.00'");
            Console.WriteLine();
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Finally, type the categoryID for the product you just added");
            Console.WriteLine();
            int categoryID = Convert.ToInt32(Console.ReadLine());
            product.CreateProduct(newProduct, price, categoryID);
            Console.WriteLine($"You just added {newProduct} with a price of {price} that is in category {categoryID}");
            Console.WriteLine();
            var allproducts = product.GetAllproducts(); 
            foreach (var prod in allproducts)
            {
                Console.WriteLine(prod.Name, prod.Price);
            }

        }
    }
}
