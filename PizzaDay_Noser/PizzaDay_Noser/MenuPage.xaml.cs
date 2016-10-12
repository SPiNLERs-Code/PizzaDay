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
        private DatabaseObject databaseObject;
        public MenuPage()
        {
            this.databaseObject = new DatabaseObject();
            InitializeComponent();
            App app = Application.Current as App;
            MessagingCenter.Subscribe<HomeView>(this, "ShowMenu", (args) => { IsPresented = true; });
            MessagingCenter.Subscribe<HomeView>(this, "ChangePage", (args) => { ChangeDetail(args.NextPage) ; });

        }
        
        private void HomeButton_OnClicked(object sender, EventArgs e)
        {
            ChangeDetail(new HomeView() {Title="Home" , Icon = "settings.png" });
        }

        private void CollectionOrder_OnClicked(object sender, EventArgs e)
        {
            ChangeDetail(new CollecOrderView() { Title = "Sammelbestellung" , Icon = "settings.png" });
        }

        private void Order_OnClicked(object sender, EventArgs e)
        {
            var oder = new BulkOrderViewModel();
            ChangeDetail(new OrderView(oder) { Title = "Bestellung:"+oder.OrderTime.ToString("dd.MM.yyyy"), Icon = "settings.png" });
        }

        private void MyColloectionOrder_Onclick(object sender, EventArgs e)
        {
            var blah = this.databaseObject.GetMyBulkOrders();
            MyCollectOrderView page = new MyCollectOrderView(blah) { Title="Meine Sammelbestellungen"};
            ChangeDetail(page);
        }

        private void ChangeDetail(Page page)
        {
            this.Icon = page.Icon;
            this.Title = page.Title;
            Detail = page;
            IsPresented = false;
        }
       
    }
}
