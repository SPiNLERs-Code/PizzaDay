using PizzaDay_Noser.Data;
using PizzaDay_Noser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.ViewModel
{
    public class FinalOrderViewModel
    {
        private DataObject _dataObject;

        public FinalOrderViewModel(int orderId)
        {
            _dataObject = new DataObject();

            var allOrder = _dataObject.GetAllOrderByBulkOrderId(orderId);

            var finalOrderItems = new List<FinalOrderItemViewModel>();
            foreach (var item in allOrder)
            {
                var tempFinalOrder = finalOrderItems.Where(x => x.Name == item.Item.Name && x.Size == item.Size.ToString()).FirstOrDefault();
                if (tempFinalOrder != null)
                {
                    tempFinalOrder.Count++;
                    tempFinalOrder.Price += item.Item.Price;
                    continue;
                }
                tempFinalOrder = new FinalOrderItemViewModel()
                {
                    Count = 1,
                    Name = item.Item.Name,
                    Price = item.Item.Price,
                    Size = item.Size.ToString() // returns "Large"
                };

                finalOrderItems.Add(tempFinalOrder);
            }
            FinalOrders = finalOrderItems;

        }
        public List<FinalOrderItemViewModel> FinalOrders { get; set; }


        public decimal Summ
        {
            get
            {
                return FinalOrders.Sum(x => x.Price);
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
                return FinalOrders.Sum(x => x.Count);
            }
        }

    }
}
