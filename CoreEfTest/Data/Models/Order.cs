using System;
using System.Collections.Generic;

namespace CoreEfTest.Data.Models
{
    public class Order
    {
        //EF convention: Property with same name as class, appended with "Id", will 
        //automatically be the primary key.
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
