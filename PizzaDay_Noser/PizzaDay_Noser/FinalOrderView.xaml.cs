using PizzaDay_Noser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PizzaDay_Noser
{
    public partial class FinalOrderView : ContentPage
    {
        public FinalOrderView(FinalOrderViewModel finalOrderViewModel)
        {
            InitializeComponent();
            FinalOrderList.ItemsSource = finalOrderViewModel.finalOrders;
            TotalCount.Text = finalOrderViewModel.Count.ToString();
            TotalPrice.Text = finalOrderViewModel.SummLabel;
        }
    }
}
