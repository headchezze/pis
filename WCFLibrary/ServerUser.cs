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
        public ServerUser()
        {
            
        }

        public void Login(WorkerPresent workerPresent)
        {
            Worker = workerPresent;
        }

        public bool FindUser(List<ServerUser> serverUsers, int userID)
        {
            if (serverUsers.FirstOrDefault(i => i.ID == userID) != null)
            {
                ID = userID;
                operationContext = OperationContext.Current;
                Worker = serverUsers.FirstOrDefault(i => i.ID == userID).Worker;

                return true;
            }

            return false;
        }
    }
}
