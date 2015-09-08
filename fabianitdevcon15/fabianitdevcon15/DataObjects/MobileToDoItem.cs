using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;

namespace fabianitdevcon15.DataObjects
{
    public class MobileToDoItem : EntityData
    {
        public string Text { get; set; }

        public bool IsFinished { get; set; }

        public bool OnMobileDevice { get; set; }
    }
}
