using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.ViewModel
{
    public class FinalOrderViewModel
    {
        public FinalOrderViewModel()
        {
            this.finalOrders = new List<FinalOrderItemViewModel>();
        }
        public List<FinalOrderItemViewModel> finalOrders { get; set; }


        public decimal Summ
        {
            get
            {
                return finalOrders.Sum(x => x.Price);
            }
        }
        
        public String SummLabel
        {
            get
            {
                return this.Summ.ToString("F") + " CHF";
            }
        }

        public int Count
        {
            get
            {
                return finalOrders.Sum(x => x.Count);
            }
        }

    }
}
