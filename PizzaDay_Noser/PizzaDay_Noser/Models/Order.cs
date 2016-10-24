using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.Models
{
    public class Order
    {
        public int Id { get; set; }

        public User Orderer { get; set; }

        public OrderItem Item { get; set; }

        public OrderSize Size { get; set; }
    }

    public enum OrderSize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }

    
}
