using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;


namespace fgwdevcone
{
	public class DisplayEvalPage : ContentPage
	{
		private ListView listView;
		private SearchBar searchBar;
		private PolicyService polService;
		public List<PolicyHistory> PHItems { get; private set; }

		public DisplayEvalPage ()
		{
			polService = new PolicyService ();

			listView = new ListView {


			};
			//need to add a Details Push Event on the ITemSelected here when working done
			listView.ItemSelected += (sender, e) => {
				//Navigation.PushAsync(new PrizeDetail(e.SelectedItem as GiveAway));
			};

			this.Title = "All Server Evaluated";
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
			PHItems = await polService.GetAllPolicyHistoryItems ();
			listView.ItemsSource = PHItems;

			var cell = new DataTemplate (typeof(TextCell));
			listView.ItemTemplate = new DataTemplate (typeof(CustomerCell));
		}
	}
}
