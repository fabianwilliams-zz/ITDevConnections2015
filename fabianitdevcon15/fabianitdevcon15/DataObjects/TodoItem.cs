using Microsoft.WindowsAzure.Mobile.Service;

namespace fabianitdevcon15.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}