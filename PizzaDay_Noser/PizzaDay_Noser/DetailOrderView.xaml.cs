using PizzaDay_Noser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PizzaDay_Noser
{
    public partial class DetailOrderView : ContentPage
    {
        public DetailOrderView(OrderItem orderItem)
        {
            InitializeComponent();
            ItemImage.Source = orderItem.Image;
            ItemName.Text = orderItem.Name;
            ItemDescription.Text = orderItem.Description;
        }
    }
}
