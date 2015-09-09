using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fgwdevcone
{
	public class DisplayCustomrsPage : ContentPage
	{
		private ListView listView;

		public DisplayCustomrsPage ()
		{

			listView = new ListView {


			};
			//need to add a Details Push Event on the ITemSelected here when working done
			listView.ItemSelected += (sender, e) => {
				//Navigation.PushAsync(new PrizeDetail(e.SelectedItem as GiveAway));
			};


			this.Title = "USA Customers";
			this.Content = new StackLayout {
				Padding = new Thickness(0, Device.OnPlatform(20,0,0),0,0),
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
				Children = {
					listView
				}

			};

		}


		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
			listView.ItemsSource = await App.CustManager.GetTasksAsync ();

			var cell = new DataTemplate (typeof(TextCell));
			listView.ItemTemplate = new DataTemplate (typeof(CustomerCell));
		}
	}
}

