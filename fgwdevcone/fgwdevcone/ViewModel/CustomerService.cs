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
	public class CustomerService
	{

		IMobileServiceTable<Customers> custTable;

		public CustomerService(IMobileServiceTable<Customers> custTable)
		{
			this.custTable = custTable;
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
				return new List<Customers> (await custTable.ReadAsync());
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

