using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.ViewModel
{
    public class FinalOrderItemViewModel
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public string PriceLabel
        {
            get
            {
                return this.Price.ToString("F")+" CHF";
            }
        }

    }
}
