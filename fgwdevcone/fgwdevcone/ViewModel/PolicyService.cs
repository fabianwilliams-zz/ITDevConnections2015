using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading;

namespace fgwdevcone
{
	public class PolicyService
	{
		private MobileServiceClient MobileService = new MobileServiceClient(
			"https://tvalmobilesvc.azure-mobile.net/",
			"XXbNZTBwHfJjnvLhNBuwmoEvEkLykc73"
		);

		public List<PolicyHistory> PHItems { get; private set;}

		private IMobileServiceSyncTable<PolicyHistory> phTable;

		public async Task InitializeAsync()
		{
			var store = new MobileServiceSQLiteStore("localdata.db");
			store.DefineTable<PolicyHistory> ();
			await this.MobileService.SyncContext.InitializeAsync(store);

			phTable = this.MobileService.GetSyncTable<PolicyHistory>();
		}

		public async Task SyncAsync()
		{
			// Comment this back in if you want auth
			//if (!await IsAuthenticated())
			//    return;
			await InitializeAsync();
			await this.MobileService.SyncContext.PushAsync();

			var query = phTable.CreateQuery()
				//.Where(td => td.Retire == false)
				;

			await phTable.PullAsync("PolicyHistories", query);
		}

		public async Task<List<PolicyHistory>> GetAllPolicyHistoryItems()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync(); 							

				PHItems = await phTable
					.Where (ga => ga.EvaluationDateTime < DateTime.Now).ToListAsync ();

			} catch (MobileServiceInvalidOperationException e) {
				return null;
			}

			return PHItems;
		}

	}
}
