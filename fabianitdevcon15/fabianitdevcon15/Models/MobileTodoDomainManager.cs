using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using fabianitdevcon15.DataObjects;
using Microsoft.WindowsAzure.Mobile.Service;

namespace fabianitdevcon15.Models
{
    class MobileTodoDomainManager : MappedEntityDomainManager<MobileToDoItem, TodoItem>
    {
        public MobileTodoDomainManager(DbContext context, HttpRequestMessage request, ApiServices services)
            : base(context, request, services)
        {
            
        }
        public override SingleResult<MobileToDoItem> Lookup(string id)
        {
            return this.LookupEntity(p => p.Id == id);
        }
        public override Task<MobileToDoItem> UpdateAsync(string id, Delta<MobileToDoItem> patch)
        {
            return this.UpdateEntityAsync(patch, id);
        }
        public override Task<bool> DeleteAsync(string id)
        {
            return this.DeleteItemAsync(id);
        }
    }
}
