using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading;

namespace fgwdevconxaml
{
	public class CustomerService
	{
		private MobileServiceClient Client = new MobileServiceClient (
			Constants.Url,
			Constants.Key);

		IMobileServiceTable<Customers> custTable;

		public CustomerService()
		{
			custTable = Client.GetTable<Customers>(); 
		
		}

		public async Task<Customers> GetTaskAsync(string id)
		{
			try 
			{
				return await custTable.LookupAsync(id);
			} 
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e) 
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}

		public async Task<List<Customers>> GetTasksAsync ()
		{
			try 
			{
				//return new List<Customers> (await custTable.ReadAsync());
				//the above will bring back all items below will only bring back customers in the USA only 
				return new List<Customers> (await custTable.Where(r=> r.Country == "USA").ToListAsync());
			} 
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e) 
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}

		public async Task SaveTaskAsync (Customers item)
		{
			if (item.ID == null)
				await custTable.InsertAsync(item);
			else
				await custTable.UpdateAsync(item);
		}

		public async Task DeleteTaskAsync (Customers item)
		{
			try 
			{
				await custTable.DeleteAsync(item);
			} 
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e) 
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
		}


	}
}

