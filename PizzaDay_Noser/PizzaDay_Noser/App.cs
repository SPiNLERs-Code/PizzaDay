using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PizzaDay_Noser
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MenuPage() {Title = "" }) { BarBackgroundColor = Color.FromHex( "#72bb53" )};
            MessagingCenter.Subscribe<string>(this, "ReloadMenuPage", (message) =>
            {
                MainPage = new NavigationPage(new MenuPage() { Title = "" }) { BarBackgroundColor = Color.FromHex("#72bb53") };
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
