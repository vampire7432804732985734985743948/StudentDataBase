using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.DataBaseJson
{
    internal class Order : IDataModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }   // Reference to Customer
        public int EmployeeId { get; set; }   // Reference to Employee
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Products { get; set; } // List of products in the order
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }    // Pending, Shipped, Delivered

        public string GetName() => "noOrder";
    }
}
