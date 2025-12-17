using System;
using System.Collections.Generic;
using Problem.StudentDataBase.DataBaseJson;
using Problem.StudentDataBase.TechnicalStuff;

internal class Program
{
    private static void Main(string[] args)
    {
        // ------------------ Customers ------------------
        var customers = new List<Customer>()
        {
            new Customer
            {
                CustomerId = 1,
                CustomerName = "John",
                CustomerType = "Regular",
                CustomerNumber = "987654321",
                Address = "Main Street",
                City = "Springfield",
                Email = "john@gmail.com",
                Phone = "123-456-7890"
            },
            new Customer
            {
                CustomerId = 2,
                CustomerName = "Alice",
                CustomerType = "Premium",
                CustomerNumber = "555987654",
                Address = "Oak Avenue",
                City = "Rivertown",
                Email = "alice@example.com",
                Phone = "321-654-9870"
            },
            new Customer
            {
                CustomerId = 3,
                CustomerName = "Bob",
                CustomerType = "Regular",
                CustomerNumber = "444123987",
                Address = "Pine Street",
                City = "Greendale",
                Email = "bob@example.com",
                Phone = "+441234567890"
            },
            new Customer
            {
                CustomerId = 4,
                CustomerName = "Clara",
                CustomerType = "Premium",
                CustomerNumber = "333222111",
                Address = "Maple Road",
                City = "Hillview",
                Email = "clara@example.com",
                Phone = "987-654-3210"
            }
        };

        // ------------------ Employees ------------------
        var employees = new List<Employee>()
        {
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Michael",
                LastName = "Smith",
                Position = "Manager",
                Department = "Sales",
                Email = "michael.smith@example.com",
                Phone = "111-222-3333",
                HireDate = new DateTime(2018, 3, 15)
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Sarah",
                LastName = "Johnson",
                Position = "Cashier",
                Department = "Retail",
                Email = "sarah.johnson@example.com",
                Phone = "222-333-4444",
                HireDate = new DateTime(2020, 7, 1)
            }
        };

        // ------------------ Products ------------------
        var products = new List<Product>()
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                Category = "Electronics",
                Price = 1200.50m,
                StockQuantity = 10,
                Supplier = "TechCorp"
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Smartphone",
                Category = "Electronics",
                Price = 800.00m,
                StockQuantity = 20,
                Supplier = "MobileInc"
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Headphones",
                Category = "Electronics",
                Price = 150.00m,
                StockQuantity = 50,
                Supplier = "SoundCo"
            }
        };

        // ------------------ Orders (EMBEDDED DOCUMENTS) ------------------
        var orders = new List<Root<Order>>()
{
    new Root<Order>(new Order
    {
        OrderId = 1,
        OrderDate = DateTime.Now,

        Customer = new Customer
        {
            CustomerId = customers[0].CustomerId,
            CustomerName = customers[0].CustomerName,
            CustomerType = customers[0].CustomerType,
            CustomerNumber = customers[0].CustomerNumber,
            Address = customers[0].Address,
            City = customers[0].City,
            Email = customers[0].Email,
            Phone = customers[0].Phone
        },

        Employee = new Employee
        {
            EmployeeId = employees[1].EmployeeId,
            FirstName = employees[1].FirstName,
            LastName = employees[1].LastName,
            Position = employees[1].Position,
            Department = employees[1].Department,
            Email = employees[1].Email,
            Phone = employees[1].Phone
            // HireDate intentionally omitted
        },

        Products = new List<OrderItem>
        {
            new OrderItem
            {
                Product = new Product
                {
                    ProductId = products[0].ProductId,
                    ProductName = products[0].ProductName,
                    Category = products[0].Category,
                    Price = products[0].Price,
                    StockQuantity = products[0].StockQuantity,
                    Supplier = products[0].Supplier
                },
                Quantity = 1,
                UnitPrice = 1200.50m,
                WasProductUsed = true
            },
            new OrderItem
            {
                Product = new Product
                {
                    ProductId = products[1].ProductId,
                    ProductName = products[1].ProductName,
                    Category = products[1].Category,
                    Price = products[1].Price,
                    StockQuantity = products[1].StockQuantity,
                    Supplier = products[1].Supplier
                },
                Quantity = 2,
                UnitPrice = 800.00m,
                WasProductUsed = false
            }
        },

        TotalAmount = 1200.50m + (2 * 800.00m),
        Status = "Pending"
    }),

    new Root<Order>(new Order
    {
        OrderId = 2,
        OrderDate = DateTime.Now,

        Customer = new Customer
        {
            CustomerId = customers[2].CustomerId,
            CustomerName = customers[2].CustomerName,
            CustomerType = customers[2].CustomerType,
            CustomerNumber = customers[2].CustomerNumber,
            Address = customers[2].Address,
            City = customers[2].City,
            Email = customers[2].Email,
            Phone = customers[2].Phone
        },

        Employee = new Employee
        {
            EmployeeId = employees[0].EmployeeId,
            FirstName = employees[0].FirstName,
            LastName = employees[0].LastName,
            Position = employees[0].Position,
            Department = employees[0].Department,
            Email = employees[0].Email,
            Phone = employees[0].Phone
            // HireDate intentionally omitted
        },

        Products = new List<OrderItem>
        {
            new OrderItem
            {
                Product = new Product
                {
                    ProductId = products[2].ProductId,
                    ProductName = products[2].ProductName,
                    Category = products[2].Category,
                    Price = products[2].Price,
                    StockQuantity = products[2].StockQuantity,
                    Supplier = products[2].Supplier
                },
                Quantity = 2,
                UnitPrice = 150.00m,
                WasProductUsed = false,
            }
        },

        TotalAmount = 2 * 150.00m,
        Status = "Shipped"
    })
};


        // ------------------ Save collections ------------------
        JSONSerializer.SaveAllData(customers, new Customer().GetName());
        JSONSerializer.SaveAllData(employees, new Employee().GetName());
        JSONSerializer.SaveAllData(products, new Product().GetName());
        JSONSerializer.SaveAllData(orders, new Order().GetName());
    }
}
