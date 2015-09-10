using System;
using Xamarin.Forms;

namespace fgwdevconxaml
{
	public class HomePageOLD : ContentPage
	{
		public HomePageOLD ()
		{
			Padding = new Thickness (5, Device.OnPlatform (20, 0, 0), 5, 5);
			Title = "ITDevConnections Demo1";

			var greetingLabel = new Label {
				Text = "Welcome to this Proof of Concept for IT Dev Connections 2015, " +
					"SQL Azure, Azure Mobile Services and Xamarin Crosss Platform Mobile Development",
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var CustomersButton = new Button {
				Text = "Load Customers"
			};

			var OrdersButton = new Button {
				Text = "Show Orders"
			};

			CustomersButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new DisplayCustomrPageOLD());
			};
			OrdersButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new DisplayOrderPageOld());
			};
			Content = new StackLayout {
				Children = {
					greetingLabel,
					CustomersButton,
					OrdersButton
				}
			};
		}
	}
}

