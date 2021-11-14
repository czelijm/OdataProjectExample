using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public DateTime OrderTime { get; set; }
        public int Quantity { get; set; }
        public int Revenue { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
