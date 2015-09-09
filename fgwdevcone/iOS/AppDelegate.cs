using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;

namespace fgwdevcone.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		UIWindow window;

		MobileServiceClient Client;
		IMobileServiceTable<Customers> custTable;
		CustomerService custService;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			global::Xamarin.Forms.Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			#region Azure stuff
			CurrentPlatform.Init ();
			Client = new MobileServiceClient (
				Constants.Url, 
				Constants.Key);	
			custTable = Client.GetTable<Customers>(); 
			custService = new CustomerService(custTable);

			App.SetCustManager (custService);
			#endregion region


			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

