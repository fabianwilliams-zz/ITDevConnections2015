using System;
using Xamarin.Forms;

namespace fgwdevcone
{
	public class HomePage: ContentPage
	{
		public HomePage ()
		{
			Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0);
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
				Navigation.PushAsync(new DisplayCustomrsPage());
			};
			OrdersButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new DisplayEvalPage());
			};
			Content = new StackLayout {
				Children = {
					CustomersButton,
					OrdersButton
				}
			};
		}
	}
}

