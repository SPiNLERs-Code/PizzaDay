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
        public Page NextPage { get; private set; }

        public HomeView()
        {
            InitializeComponent();
            new_bulk_order.Clicked += (sender, e) => { this.ChangeDetail(new CollecOrderView() { Title = "Sammelbestellung" , Icon ="settings.png" }); };
            OpenBulkOrders.Children.Add(CreateBulkOrderButton(new BulkOrderViewModel()));
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

        private Button CreateBulkOrderButton(BulkOrderViewModel bulkOrder)
        {
            var button = new Button();

            button.HeightRequest = 50;
            button.TextColor = Color.FromHex("#000");
            button.BorderRadius = 0;
            button.BackgroundColor = Color.FromHex("#72bb53");
            button.Text = "Bestellung:" + bulkOrder.OrderTime.ToString("dd.MM.yyyy");
            button.Clicked += (sender, e) => { this.OpenOrder(bulkOrder.Id); };
            return button;
        }

        private void OpenOrder(int orderId)
        {
            DatabaseObject dataObject = new DatabaseObject();
            var bulkOrder = dataObject.GetBulkOrderByID(orderId);
            var newPage = new OrderView(bulkOrder) { Title = "Bestellung:" + bulkOrder.OrderTime.ToString("dd.MM.yyyy"), Icon = "settings.png" };
            ChangeDetail(newPage);
        }
    }
}
