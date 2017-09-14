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
        ActivityIndicator loading;

		public ListPage()
        {
            Title = "My Pets";
            BackgroundColor = Color.LightGray;

            loading = new ActivityIndicator();
            loading.IsRunning = true;
            loading.IsVisible = true;
            loading.HorizontalOptions = LayoutOptions.CenterAndExpand;
            loading.VerticalOptions = LayoutOptions.CenterAndExpand;

            ScrollView scroll = new ScrollView();
            StackLayout listPetsLayout = new StackLayout();

			FillPets(listPetsLayout);

            listPetsLayout.Children.Add(loading);
            scroll.Content = listPetsLayout;
            Content = scroll;
        }

        protected async void FillPets(StackLayout listPetsLayout)
        {
            PetServices service = new PetServices();
			PetBoxView petBoxView = new PetBoxView();

            ObservableCollection<pet> pets = await service.GetPetsAsync();

            foreach (pet mypet in pets)
			{
				listPetsLayout.Children.Add(petBoxView.createPetBoxLayout(mypet));
			}

            loading.IsRunning = false;
            loading.IsVisible = false;
        }
    }
}

