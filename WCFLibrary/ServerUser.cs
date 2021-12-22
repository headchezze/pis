using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFLibrary
{
    public class ServerUser
    {
        public int ID { get; set; }
        public WorkerPresent Worker { get; private set; }

        public OperationContext operationContext { get; private set; }

        public ServerUser(int ID, OperationContext operationContext)
        {
            this.ID = ID;
            this.operationContext = operationContext;
        }
    }
}
