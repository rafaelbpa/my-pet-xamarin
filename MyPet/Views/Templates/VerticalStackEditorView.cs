using System;

using Xamarin.Forms;

namespace MyPet.Views.Templates
{
    public class VerticalStackEditorView : ContentPage
    {
		public static StackLayout createVerticalStackEditorView(string label, string text)
		{
			StackLayout horizontalLayout = new StackLayout();

            horizontalLayout.Orientation = StackOrientation.Vertical;
            horizontalLayout.Padding = new Thickness(16, 8, 16, 8);

			Label mLabel = new Label();
			mLabel.FontAttributes = FontAttributes.Bold;
			mLabel.HorizontalOptions = LayoutOptions.Start;
			mLabel.Text = label;
            mLabel.TextColor = Color.Black;

			Label mText = new Label();
			mText.HorizontalOptions = LayoutOptions.StartAndExpand;
			mText.Text = text;
            mText.TextColor = Color.Black;

			horizontalLayout.Children.Add(mLabel);
			horizontalLayout.Children.Add(mText);

			return horizontalLayout;
		}
    }
}

