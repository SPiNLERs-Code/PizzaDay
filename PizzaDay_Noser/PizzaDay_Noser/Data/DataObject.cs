using PizzaDay_Noser.Models;
using PizzaDay_Noser.DemoDatas;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PizzaDay_Noser.Data
{
    public class DataObject
    {
        private User _user;
        private DemoData _demoData;

        public DataObject()
        {
            _demoData = DemoData.DemoDataInstance;
            _user = _demoData.SavedUsers.FirstOrDefault();
        }

        public BulkOrder GetBulkOrderByID(int orderID)
        {
            return _demoData.SavedBulkOrders.Where(x => x.Id == orderID).FirstOrDefault();
        }

        public List<BulkOrder> GetOpenBulkOrder()
        {
            return _demoData.SavedBulkOrders.Where(x => x.IsOrdering == true).ToList();
        }

        public List<BulkOrder> GetMyBulkOrders()
        {
            return _demoData.SavedBulkOrders.Where(x => x.Creator.Id == 1).ToList();
        }

        public List<Restaurant> GetAllRestaurants()
        {
           return _demoData.GetAllRestaurants();
        }

        public List<Order> GetAllOrderByBulkOrderId(int bulkOrderId)
        {
            var bulkOrder = _demoData.SavedBulkOrders.Where(x => x.Id == bulkOrderId).FirstOrDefault();
            return bulkOrder.Items;
        }

        public void SaveBulkOrder(TimeSpan deliveryTime, DateTime deliveryDate, TimeSpan deadlineTime, DateTime deadlineDate, string description, int restaurantId)
        {
            BulkOrder newCreatedBulkOrder = new BulkOrder
            {
                Creator = _user,
                DeliveryTime = deliveryDate + deliveryTime,
                OrderDeadline = deadlineDate + deliveryTime,
                Description = description,
                IsOrdering = true,
                Items = new List<Order>(),
                Restaurant = _demoData.GetAllRestaurants().Where(x => x.Id == restaurantId).FirstOrDefault()
            };

            _demoData.SetNewBulkOrder(newCreatedBulkOrder);
        }

        public void SaveOrder(OrderItem orderItem, OrderSize orderSize, int bulkOrderId)
        {
            Order order = new Order()
            {
                Item = orderItem,
                Orderer = _user,
                Size = orderSize
            };

            var bulkorderToUpdate = _demoData.SavedBulkOrders.Where(x => x.Id == bulkOrderId).FirstOrDefault();
            bulkorderToUpdate.Items.Add(order);

            _demoData.UpdateBulkOrder(bulkorderToUpdate);
        }

        private List<OrderItem> GetAllOrderItemsFromBulkOrder(int orderID)
        {
           return _demoData.GetAllOrderItems();
        }

    }
}
