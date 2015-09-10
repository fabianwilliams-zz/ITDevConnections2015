using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fgwdevconxaml
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			this.Title = "ITDevConnections Demo1";
		}

		void OnCustomerButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new DisplayCustomr());
		}

		void OnOrderButtonClicked(object sender, EventArgs e)
		{
			//not yet implemented
		}
	}
}

