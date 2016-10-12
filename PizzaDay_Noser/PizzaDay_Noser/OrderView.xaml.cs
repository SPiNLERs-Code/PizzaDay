using PizzaDay_Noser.Models;
using PizzaDay_Noser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PizzaDay_Noser
{
    public partial class OrderView : ContentPage
    {
        public OrderView(BulkOrderViewModel bulkOrder)
        {
            InitializeComponent();
            OrderItemList.ItemsSource = bulkOrder.OrderItems;
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((ListView)sender);
            var it = (OrderItem)mi.SelectedItem;

            var newPage = new DetailOrderView(it) { Title = it.Name, Icon = "settings.png" };
            Navigation.PushAsync(newPage);
        }

    }
}
