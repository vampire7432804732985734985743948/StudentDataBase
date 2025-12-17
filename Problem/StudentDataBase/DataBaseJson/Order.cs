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
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public List<OrderItem> Products { get; set; }

        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public string GetName() => "noOrder";
    }
}
