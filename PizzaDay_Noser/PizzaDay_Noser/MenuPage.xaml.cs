using Microsoft.CSharp.RuntimeBinder;
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
    public partial class MenuPage : MasterDetailPage
    {
        private DataObject dataObject;
        public MenuPage()
        {
            this.dataObject = new DataObject();
            InitializeComponent();
            App app = Application.Current as App;
            MessagingCenter.Subscribe<HomeView>(this, "ShowMenu", (args) => { IsPresented = true; });
            MessagingCenter.Subscribe<HomeView>(this, "ChangePage", (args) => { ChangeDetail(args.NextPage); });
            MessagingCenter.Subscribe<string>(this, "SuccessfulMessage", async (message) =>
            {
                await DisplayAlert("", message, "OK");
            });

        }


        private void HomeButton_OnClicked(object sender, EventArgs e)
        {
            ChangeDetail(new HomeView() { Title = "", Icon = "settings.png" });
        }

        private void CollectionOrder_OnClicked(object sender, EventArgs e)
        {
            PushPage(new CollecOrderView() { Title = "Sammelbestellung", Icon = "settings.png" });
        }


        private void MyColloectionOrder_Onclick(object sender, EventArgs e)
        {
            var myBulkOrder = this.dataObject.GetMyBulkOrders();
            MyCollectOrderView page = new MyCollectOrderView(myBulkOrder) { Title = "Meine Sammelbestellungen" };
            PushPage(page);
        }

        private void ChangeDetail(Page page)
        {
            this.Icon = page.Icon;
            this.Title = page.Title;
            Detail = page;
            IsPresented = false;
        }

        private void PushPage(Page page)
        {
            Navigation.PushAsync(page);
        }

    }
}
