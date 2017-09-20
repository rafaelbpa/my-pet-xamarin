using System;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using MyPet.Models;
using MyPet.Views.Pages;
using Xamarin.Forms;

namespace MyPet.Views.Templates
{
    public class PetBoxView : ContentPage
    {
        public StackLayout createPetBoxLayout(pet myPet)
        {
            StackLayout box = new StackLayout();

            box.Orientation = StackOrientation.Vertical;
            box.VerticalOptions = LayoutOptions.Start;

            Label petName = new Label();
            petName.Text = myPet.name;
            petName.TextColor = Color.Black;
            petName.HorizontalOptions = LayoutOptions.CenterAndExpand;
            petName.FontSize = 18.0f;
            petName.FontAttributes = FontAttributes.Bold;
            petName.Margin = new Thickness(0, 10, 0, 10);

	    var cachedImage = new CachedImage()
	    {
            	HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
		CacheDuration = TimeSpan.FromDays(7),
		DownsampleToViewSize = true,
		RetryCount = 0,
		RetryDelay = 250,
		LoadingPlaceholder = "loading.png",
		ErrorPlaceholder = "error.png",
                Source = myPet.picture
	    };

	    var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Command = new Command(() => Navigation.PushAsync(new DetailPage(myPet)));
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(myPet));
            };

            box.BackgroundColor = Color.White;
            box.Children.Add(cachedImage);
            box.Children.Add(petName);
            box.GestureRecognizers.Add(tapGestureRecognizer);

            return box;
        }
    }
}
