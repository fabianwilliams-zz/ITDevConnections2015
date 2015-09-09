using System;

using Xamarin.Forms;

namespace fgwdevcone
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new HomePage());
		}

		#region Azure stuff
		static CustomerService custService;

		public static CustomerService CustManager {
			get { return custService; }
			set { custService = value; }
		}

		public static void SetCustManager (CustomerService custService)
		{
			CustManager = custService;
		}
		#endregion

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

