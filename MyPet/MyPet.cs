using System;
using MyPet.Views;
using MyPet.Views.Pages;
using Xamarin.Forms;

namespace MyPet
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new ListPage());
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
