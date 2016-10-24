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
    public partial class MyCollectOrderView : ContentPage
    {
        public MyCollectOrderView(List<BulkOrder> myBulkOrders)
        {
            InitializeComponent();
            MyBulkOrderList.ItemsSource = myBulkOrders;
        }

        public void OnMore(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            BulkOrder bulkOrder = listView.SelectedItem as BulkOrder;
            FinalOrderViewModel vm = new FinalOrderViewModel(bulkOrder.Id);
            var newPage = new FinalOrderView(vm);
            Navigation.PushAsync(newPage);
        }
    }
}
