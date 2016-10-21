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
            FinalOrderViewModel vm = new FinalOrderViewModel();
            vm.finalOrders.Add( new FinalOrderItemViewModel() { Count = 4, Name = "Hawaii", Price = 30, Size = "Small" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 3, Name = "Hawaii", Price = 20, Size = "Medium" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 6, Name = "Hawaii", Price = 50, Size = "Large" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 4, Name = "Hawaii", Price = 30, Size = "Small" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 3, Name = "Hawaii", Price = 20, Size = "Medium" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 6, Name = "Hawaii", Price = 50, Size = "Large" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 4, Name = "Hawaii", Price = 30, Size = "Small" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 3, Name = "Hawaii", Price = 20, Size = "Medium" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 6, Name = "Hawaii", Price = 50, Size = "Large" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 4, Name = "Hawaii", Price = 30, Size = "Small" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 3, Name = "Hawaii", Price = 20, Size = "Medium" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 6, Name = "Hawaii", Price = 50, Size = "Large" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 4, Name = "Hawaii", Price = 30, Size = "Small" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 3, Name = "Hawaii", Price = 20, Size = "Medium" });
            vm.finalOrders.Add(new FinalOrderItemViewModel() { Count = 6, Name = "Hawaii", Price = 50, Size = "Large" });
            var newPage = new FinalOrderView(vm);
            Navigation.PushAsync(newPage);
        }
    }
}
