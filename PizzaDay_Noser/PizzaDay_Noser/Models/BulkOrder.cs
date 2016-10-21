using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.Models
{
    public class BulkOrder
    {
        public int Id { get; set; }

        public Restaurant Restaurant { get; set; }

        public String Description { get; set; }

        public bool IsOrdering { get; set; }

        public DateTime OrderDeadline { get; set; }

        public DateTime DeliveryTime { get; set; }

        public User Creator { get; set; }

        public List<Order> Items { get; set; }
    }
}
