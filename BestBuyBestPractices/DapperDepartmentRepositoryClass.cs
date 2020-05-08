using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BestBuyBestPractices
{
    class DapperDepartmentRepositoryClass : IDepartmentRepository
    {
        
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepositoryClass(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM Departments;").ToList();
        }


        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }
        
        public IEnumerable<Product> GetAllproducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products");
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, price, categoryID) VALUES (@name, @price, @categoryID)",
                new { name = name, price = price, categoryID = categoryID});

        }

        public void UpdateProduct(int productID, string name, double price)
        {

        }
    }
}
