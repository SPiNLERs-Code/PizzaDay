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
    public partial class CollecOrderView : ContentPage
    {
        private DataObject _dataObject;
        private List<Restaurant> _restaurants;


        public CollecOrderView()
        {
            _dataObject = new DataObject();
            InitializeComponent();
            InitialzeFormular();
        }

        private void InitialzeFormular()
        {
            ErrorText.IsVisible = false;

            _restaurants = _dataObject.GetAllRestaurants();
            foreach (var restaurant in _restaurants)
            {
                RestaurantPicker.Items.Add(restaurant.Name);
            }

            DeadlineTime.Time = new TimeSpan(11, 0, 0);
            DeliveryTime.Time = new TimeSpan(12, 0, 0);

            NewBulkOrder.Clicked += NewBulkOrder_Clicked;
        }

        private void NewBulkOrder_Clicked(object sender, EventArgs e)
        {
            CheckUserInput();

            var errorText = CheckUserInput();

            if(errorText != "")
            {
                ErrorText.Text = errorText;
                ErrorText.IsVisible = true;
                return;
            }

            _dataObject.SaveBulkOrder(DeliveryTime.Time, DeliveryDate.Date, DeadlineTime.Time, DeadlineDate.Date, Description.Text, _restaurants[RestaurantPicker.SelectedIndex].Id);
            MessagingCenter.Send<string>("Reload", "ReloadOpenBulkOrders");
            MessagingCenter.Send<string>("", "ReloadMenuPage");
            MessagingCenter.Send<string>("Die Sammelbestellung wurde erfolgreich erstellt!", "SuccessfulMessage");
            ErrorText.IsVisible = true;
        }

        private string CheckUserInput()
        {

            var isn = RestaurantPicker.SelectedIndex;

            if (DeliveryDate.Date == null || DeliveryDate.Date < DateTime.Now.Date)
            {
                return "Das Lieferdatum darf nicht in der Vergangenheit liegen oder leer sein.";
            }
            if (DeadlineDate.Date == null || DeadlineDate.Date < DateTime.Now.Date)
            {
                return "Die Bestellfrist darf nicht in der Vergangenheit liegen oder leer sein.";
            }

            if (DeadlineDate.Date > DeliveryDate.Date)
            {
                return "Die Bestellfrist darf nicht nach der Lieferzeit sein.";
            }

            if (Description.Text == null || Description.Text == "")
            {
                return "Die Beschreibung darf nicht leer sein.";
            }

            if(RestaurantPicker.SelectedIndex == -1)
            {
                return "Bitte wähle ein Restaurant aus.";
            }

            return "";
        }

        
    }
}
