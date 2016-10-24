using PizzaDay_Noser.Data;
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
        private int _bulkOrderId;
        private DataObject _dataObject;
        private OrderItem _orderItem;

        public DetailOrderView(OrderItem orderItem, int bulkOrderId)
        {
            InitializeComponent();

            _bulkOrderId = bulkOrderId;
            _dataObject = new DataObject();
            _orderItem = orderItem;

            ItemImage.Source = orderItem.Image;
            ItemName.Text = orderItem.Name;
            ItemDescription.Text = orderItem.DescriptionText;
            SizeButtons.Children.Add(GetSizeButton("Klein",OrderSize.Small));
            SizeButtons.Children.Add(GetSizeButton("Normal", OrderSize.Medium));
            SizeButtons.Children.Add(GetSizeButton("Gross", OrderSize.Large));

        }

        private Button GetSizeButton(string text, OrderSize orderSize)
        {
            Button sizeButton = new Button();
            sizeButton.Text = text;
            sizeButton.HeightRequest = 45;
            sizeButton.TextColor = Color.FromHex("#000");
            sizeButton.BorderRadius = 0;
            sizeButton.BackgroundColor = Color.FromHex("#AAA");
            sizeButton.Clicked += (sender, e) => { this.AddOrder(orderSize); };

            return sizeButton;
        }

        private void AddOrder(OrderSize orderSize)
        {
            _dataObject.SaveOrder(_orderItem, orderSize, _bulkOrderId);
            MessagingCenter.Send<string>("", "ReloadMenuPage");
            MessagingCenter.Send<string>("Die Bestellung wurde erfolgreich aufgegeben!", "SuccessfulMessage");
        }
    }
}
