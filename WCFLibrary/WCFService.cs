using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WCFService" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class WCFService : IWCFService
    {
        List<ServerUser> users = new List<ServerUser>();

        static int nextID = 1;

        public void AddProductToOffice(int id, ICollection<OfficeProductsRepresent> officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public int Connect()
        {
            ServerUser user = new ServerUser(nextID, OperationContext.Current);
            users.Add(user);

            nextID++;

            return user.ID;
        }

        public void CreateNewOffice(int id, OfficeRepresent officeRepresent, OfficeRepresent to = null)
        {
            throw new NotImplementedException();
        }

        public void CreateNewProduct(int id, ProductRepresent productRepresent)
        {
            throw new NotImplementedException();
        }

        public void DeleteOffice(int id, OfficeRepresent officeRepresent)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductFromOffice(int id, OfficeProductsRepresent officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(int id)
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if(user != null)
            {
                users.Remove(user);
            }
        }

        public ICollection<OfficeRepresent> FindOrgs(int id, string orgName = "", string orgType = "")
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                ICollection<OfficeRepresent> foundOrg = user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindOrgsCallback(orgName, orgType);

                return foundOrg;
            }

            return null;
        }

        public ICollection<OfficeProductsRepresent> FindProductsByOffice(string orgName, string officeLocation)
        {
            throw new NotImplementedException();
        }
    }
}
