using System;
using System.Collections.Generic;
using Problem.StudentDataBase.DataBaseJson;
using Problem.StudentDataBase.TechnicalStuff;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Root<Customer>> customerRoots = new List<Root<Customer>>()
        {
            new Root<Customer>(new Customer()
            {
                CustomerId = 1,
                CustomerName = "John",
                CustomerType = "Regular",
                CustomerNumber = "987654321",
                Address = "Main Street",
                City = "Springfield",
                Email = "john@gmail.com",
                Phone = "123-456-7890"
            }),
            new Root<Customer>(new Customer()
            {
                CustomerId = 2,
                CustomerName = "Alice",
                CustomerType = "Premium",
                CustomerNumber = "555987654",
                Address = "Oak Avenue",
                City = "Rivertown",
                Email = "alice@example.com",
                Phone = "321-654-9870"
            }),
            new Root<Customer>(new Customer()
            {
                CustomerId = 3,
                CustomerName = "Bob",
                CustomerType = "Regular",
                CustomerNumber = "444123987",
                Address = "Pine Street",
                City = "Greendale",
                Email = "bob@example.com",
                Phone = "+441234567890"
            }),
            new Root<Customer>(new Customer()
            {
                CustomerId = 4,
                CustomerName = "Clara",
                CustomerType = "Premium",
                CustomerNumber = "333222111",
                Address = "Maple Road",
                City = "Hillview",
                Email = "clara@example.com",
                Phone = "987-654-3210"
            })
        };

        // ------------------ Employees ------------------
        List<Root<Employee>> employeeRoots = new List<Root<Employee>>()
        {
            new Root<Employee>(new Employee()
            {
                EmployeeId = 1,
                FirstName = "Michael",
                LastName = "Smith",
                Position = "Manager",
                Department = "Sales",
                Email = "michael.smith@example.com",
                Phone = "111-222-3333",
                HireDate = new DateTime(2018, 3, 15)
            }),
            new Root<Employee>(new Employee()
            {
                EmployeeId = 2,
                FirstName = "Sarah",
                LastName = "Johnson",
                Position = "Cashier",
                Department = "Retail",
                Email = "sarah.johnson@example.com",
                Phone = "222-333-4444",
                HireDate = new DateTime(2020, 7, 1)
            })
        };

        // ------------------ Products ------------------
        List<Root<Product>> productRoots = new List<Root<Product>>()
        {
            new Root<Product>(new Product()
            {
                ProductId = 1,
                ProductName = "Laptop",
                Category = "Electronics",
                Price = 1200.50m,
                StockQuantity = 10,
                Supplier = "TechCorp"
            }),
            new Root<Product>(new Product()
            {
                ProductId = 2,
                ProductName = "Smartphone",
                Category = "Electronics",
                Price = 800.00m,
                StockQuantity = 20,
                Supplier = "MobileInc"
            }),
            new Root<Product>(new Product()
            {
                ProductId = 3,
                ProductName = "Headphones",
                Category = "Electronics",
                Price = 150.00m,
                StockQuantity = 50,
                Supplier = "SoundCo"
            })
        };

        // ------------------ Orders ------------------
        List<Root<Order>> orderRoots = new List<Root<Order>>()
        {
            new Root<Order>(new Order()
            {
                OrderId = 1,
                CustomerId = 1,
                EmployeeId = 2,
                OrderDate = DateTime.Now,
                Products = new List<OrderItem>()
                {
                    new OrderItem() { ProductId = 1, Quantity = 1, Price = 1200.50m },
                    new OrderItem() { ProductId = 2, Quantity = 2, Price = 1600.00m }
                },
                TotalAmount = 2800.50m,
                Status = "Pending"
            }),
            new Root<Order>(new Order()
            {
                OrderId = 2,
                CustomerId = 3,
                EmployeeId = 1,
                OrderDate = DateTime.Now,
                Products = new List<OrderItem>()
                {
                    new OrderItem() { ProductId = 3, Quantity = 2, Price = 300.00m }
                },
                TotalAmount = 300.00m,
                Status = "Shipped"
            })
        };

        // ------------------ Save all data ------------------
        JSONSerializer.SaveAllData(customerRoots, "Customers");
        JSONSerializer.SaveAllData(employeeRoots, "Employee");
        JSONSerializer.SaveAllData(productRoots, "Products");
        JSONSerializer.SaveAllData(orderRoots, "Orders");
    }
}

