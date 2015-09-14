using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace fgwdevconxaml
{
	public partial class DisplayCustomr : ContentPage
	{
		private CustomerService custService;

		public DisplayCustomr ()
		{
			InitializeComponent ();
			custService = new CustomerService ();
			this.Title = "All USA Customers";
		}

		void OnItemSelected (object sender, EventArgs e)
		{
			//Navigation.PushAsync(new DisplayCustomerDetailsPage(e.SelectedItem as GiveAway));
			Navigation.PushAsync(new DisplayCustomerDetailsPage());
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
			listView.ItemsSource = await custService.GetTasksAsync();
			listView.ItemTemplate = new DataTemplate (typeof(CustomerCell));
		}

	}
}

