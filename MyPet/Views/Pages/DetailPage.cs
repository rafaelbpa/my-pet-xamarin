using System;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using MyPet.Models;
using MyPet.Views.Templates;
using Plugin.ExternalMaps;
using Xamarin.Forms;

namespace MyPet.Views.Pages
{
    public class DetailPage : ContentPage
    {
        public DetailPage(pet myPet)
        {
            ScrollView scroll = new ScrollView();
            StackLayout layout = new StackLayout();
            layout.BackgroundColor = Color.White;

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

            Button btnRoute = new Button()
            {
                BackgroundColor = Color.Accent,
                TextColor = Color.White,
                Text = "I WANNA HUG THIS PET",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18.0f,
                Margin = new Thickness(10, 10),
                Command = new Command(async () => await openMapsAsync(myPet)),
			};

            StackLayout nameStack = VerticalStackEditorView.createVerticalStackEditorView("Name", myPet.name);
			StackLayout breedStack = VerticalStackEditorView.createVerticalStackEditorView("Breed", myPet.breed);
			StackLayout weightStack = VerticalStackEditorView.createVerticalStackEditorView("Weight", myPet.weight.ToString());
			StackLayout descriptionStack = VerticalStackEditorView.createVerticalStackEditorView("Description", myPet.description);

			layout.Children.Add(cachedImage);
            layout.Children.Add(nameStack);
            layout.Children.Add(breedStack);
            layout.Children.Add(weightStack);
            layout.Children.Add(descriptionStack);
            layout.Children.Add(btnRoute);


            scroll.Content = layout;
            Content = scroll;
        }

        public async Task openMapsAsync(pet myPet)
        {
            var success = await CrossExternalMaps.Current.NavigateTo(myPet.name, myPet.latitude, myPet.longitude);
        }
    }
}

