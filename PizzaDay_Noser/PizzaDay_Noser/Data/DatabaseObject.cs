using PizzaDay_Noser.Models;
using PizzaDay_Noser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzaDay_Noser.Data
{
    public class DatabaseObject
    {
        public BulkOrderViewModel GetBulkOrderByID(int orderID)
        {
            var bulk = new BulkOrderViewModel();
            bulk.Description = "Dies ist eine Sammelbestellung.";
            bulk.Id = orderID;
            bulk.OrderTime = DateTime.Now.AddHours(1);
            bulk.Restaurant = "Vapiano";
            bulk.OrderItems = GetAllOrderItemsFromBulkOrder(orderID);
            return bulk;
        }

        public List<BulkOrderViewModel> GetMyBulkOrders()
        {
            List<BulkOrderViewModel> items = new List<BulkOrderViewModel>();

            BulkOrderViewModel bulkOrder = new BulkOrderViewModel();
            bulkOrder.Description = "Pizza bestelen heute!";
            bulkOrder.Id = 1;
            bulkOrder.OrderItems = GetAllOrderItemsFromBulkOrder(0);
            bulkOrder.OrderTime = DateTime.Now.AddHours(3);
            bulkOrder.Restaurant = "Dieci";
            bulkOrder.IsOrdering = true;
            items.Add(bulkOrder);

            BulkOrderViewModel bulkOrder2 = new BulkOrderViewModel();
            bulkOrder2.Description = "Meldet euch an!";
            bulkOrder2.Id = 2;
            bulkOrder2.OrderItems = GetAllOrderItemsFromBulkOrder(0);
            bulkOrder2.OrderTime = DateTime.Now.AddDays(-1);
            bulkOrder2.Restaurant = "PizzaBlitz";
            bulkOrder2.IsOrdering = false;
            items.Add(bulkOrder2);

            BulkOrderViewModel bulkOrder3 = new BulkOrderViewModel();
            bulkOrder3.Description = "Ich freue mich!";
            bulkOrder3.Id = 2;
            bulkOrder3.OrderItems = GetAllOrderItemsFromBulkOrder(0);
            bulkOrder3.OrderTime = DateTime.Now.AddDays(-5);
            bulkOrder3.Restaurant = "Dieci";
            bulkOrder3.IsOrdering = false;
            items.Add(bulkOrder3);

            return items;
        }

        private List<OrderItem> GetAllOrderItemsFromBulkOrder(int orderID)
        {
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem { Name = "Margherita", ImageUrl = "http://www.dieci.ch/kurier/images/1.jpg", Description = "Tomaten, Mozzarella, Oregano" });
            items.Add(new OrderItem { Name = "Stromboli", ImageUrl = "http://www.dieci.ch/kurier/images/2.jpg", Description = "Tomaten, Mozzarella, frische Peperoncini, Oliven, Oregano" });
            items.Add(new OrderItem { Name = "Napoli", ImageUrl = "http://www.dieci.ch/kurier/images/3.jpg", Description = "Tomaten, Mozzarella, Sardellen, Kapern, Oregano" });
            items.Add(new OrderItem { Name = "Prosciutto", ImageUrl = "http://www.dieci.ch/kurier/images/4.jpg", Description = "Tomaten, Mozzarella, Hinterschinken, Oregano" });

            items.Add(new OrderItem { Name = "Funghi", ImageUrl = "http://www.dieci.ch/kurier/images/5.jpg", Description = "Tomaten, Mozzarella, frische Champignons, Oregano" });
            items.Add(new OrderItem { Name = "Prosciutto e funghi", ImageUrl = "http://www.dieci.ch/kurier/images/6.jpg", Description = "Tomaten, Mozzarella, Hinterschinken, frische Champignons, Oregano" });
            items.Add(new OrderItem { Name = "Quattro stagioni", ImageUrl = "http://www.dieci.ch/kurier/images/7.jpg", Description = "Tomaten, Mozzarella, Hinterschinken, Artischocken, frische Champignons, Peperoni, Oregano" });
            items.Add(new OrderItem { Name = "Rustica", ImageUrl = "http://www.dieci.ch/kurier/images/8.jpg", Description = "Tomaten, Mozzarella, Hinterschinken, Speck, Zwiebeln, Knoblauch, Oregano" });
            return items;
        }


    }
}
