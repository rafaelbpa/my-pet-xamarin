using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MyPet.Models;
using MyPet.Services;
using MyPet.Views.Templates;
using Xamarin.Forms;

namespace MyPet.Views.Pages
{
    public class ListPage : ContentPage
    {
		public ListPage()
        {
            Title = "My Pets";
            BackgroundColor = Color.LightGray;

            ScrollView scroll = new ScrollView();
            StackLayout listPetsLayout = new StackLayout();

            PetServices service = new PetServices();
            ObservableCollection<pet> pets = Task.Run(() => service.GetPetsAsync()).Result;

            PetBoxView petBoxView = new PetBoxView();

			foreach(pet peto in pets) {
			    listPetsLayout.Children.Add(petBoxView.createPetBoxLayout(peto));
			}

            scroll.Content = listPetsLayout;
            Content = scroll;
        }
    }
}

