using PizzaDay_Noser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.ViewModel
{
    public class BulkOrderViewModel
    {
        public BulkOrderViewModel()
        {
            this.Id = 0;
            this.OrderTime = DateTime.Now;
            this.Description = "Dies ist eine Testbestellung.";
            this.Restaurant = "Demo Restaurant";
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }

        public DateTime OrderTime { get; set; }

        public String Description { get; set; }

        public String Restaurant { get; set; }

        public String Title { get { return OrderTime.ToString("dd.MM.yy") + " - " + this.Restaurant; } }

        public bool IsOrdering { get; set; }

        public string Opacity { get
            {
                if (this.IsOrdering) { return "1"; };
                return "0.4";
            } }

        public List<OrderItem> OrderItems { get; set; }
    }
}
