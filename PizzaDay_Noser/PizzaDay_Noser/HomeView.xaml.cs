using PizzaDay_Noser.Data;
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
    public partial class HomeView : ContentPage
    {
        DataObject _dataObject;

        public Page NextPage { get; private set; }

        public HomeView()
        {
            _dataObject = new DataObject();
            InitializeComponent();
            new_bulk_order.Clicked += (sender, e) => { this.ChangeDetail(new CollecOrderView() { Title = "Sammelbestellung" , Icon ="settings.png" }); };

            LoadOpenBulkOrders();

            MessagingCenter.Subscribe<string>(this, "ReloadOpenBulkOrders", (message) =>
            {
                LoadOpenBulkOrders();
            });

            

        }

        private void LoadOpenBulkOrders()
        {
            OpenBulkOrders.Children.Clear();
            foreach (var item in _dataObject.GetOpenBulkOrder())
            {
                OpenBulkOrders.Children.Add(CreateBulkOrderButton(item));
            }
        }

        private void ChangeDetail(Page page)
        {
            this.NextPage = page;
            MessagingCenter.Send(this, "ChangePage");
        }

        private void AddBulOrderButtonEvents()
        {
            new_bulk_order.Clicked += (sender, e) => { this.ChangeDetail(new CollecOrderView() { Title = "Sammelbestellung", Icon = "settings.png" }); };
        }

        private Button CreateBulkOrderButton(BulkOrder bulkOrder)
        {
            var button = new Button();

            button.HeightRequest = 50;
            button.TextColor = Color.FromHex("#000");
            button.BorderRadius = 0;
            button.BackgroundColor = Color.FromHex("#72bb53");
            button.Text = bulkOrder.Restaurant.Name+" - " + bulkOrder.DeliveryTime.ToString("dd.MM.yyyy");
            button.Clicked += (sender, e) => { this.OpenOrder(bulkOrder.Id); };
            return button;
        }

        private void OpenOrder(int orderId)
        {
            DataObject dataObject = new DataObject();
            var bulkOrder = dataObject.GetBulkOrderByID(orderId);
            Navigation.PushAsync(new OrderView(bulkOrder) { Title = "Bestellung:" + bulkOrder.DeliveryTime.ToString("dd.MM.yyyy"), Icon = "settings.png" });
        }
    }
}
