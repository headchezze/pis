using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WCFService" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WCFService : IWCFService
    {
        delegate void FindOfficesDelegate(List<OfficeRepresent> offices);
        List<ServerUser> users = new List<ServerUser>();
        pisanimalsEntities context = new pisanimalsEntities();

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

        public void CreateNewProduct(int id, ProductRepresent productRepresent)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductFromOffice(int id, OfficeProductsRepresent officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(int id)
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                users.Remove(user);
            }
        }

        public void FindOrgs(int id, FindOfficeFlag flag, string orgName = "", string orgType = "")
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                Dictionary<FindOfficeFlag,FindOfficesDelegate> methods = new Dictionary<FindOfficeFlag, FindOfficesDelegate>()
                {
                    { FindOfficeFlag.Main, user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindOrgsToMainCallback },
                    { FindOfficeFlag.AddressAdd, user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindOrgsToAddressAddCallback }
                };

                List<OfficeRepresent> list = new List<OfficeRepresent>().AddOffices(context.Offices.GetOffices(orgName, orgType));

                methods[flag]?.Invoke(list);
            }   
        }

        public void FindProductsByOffice(int id, string orgName, string address)
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                OfficeRepresent office = new OfficeRepresent(address, orgName, context.OfficeProducts.GetProducts(address, orgName));

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindProductsByOfficeCallback(office);
            }
        }

        public void GetOrgsAndTypes(int id)
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                List<string> orgs = new List<string>();
                foreach (Orgs org in context.Orgs.ToList())
                {
                    orgs.Add(org.OrgName);
                }

                List<string> types = new List<string>();
                foreach (OrgTypes org in context.OrgTypes.ToList())
                {
                    types.Add(org.TypeName);
                }
                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().GetOrgsAndTypesCallback(orgs, types);
            }
        }

        public void Login(int id, string login, string password)
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                Workers worker = context.Workers.GetWorker(login, password);

                if(worker != null)
                {
                    user.Login(new WorkerPresent(worker.FullName, worker.Org, worker.Login, worker.Password));
                    user.operationContext.GetCallbackChannel<IWCFServiceCallback>().LoginCallback(user.Worker.Fullname, user.Worker.Organization);
                    return;
                }

                    user.operationContext.GetCallbackChannel<IWCFServiceCallback>().LoginCallback(String.Empty, String.Empty);
            }
        }

        public void AddNewOffice(int id, string org, string addressTo, string addressFrom = "")
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                Offices office = new Offices(addressTo, org);

                if (addressFrom != "")
                {
                    IQueryable<OfficeProducts> products = context.OfficeProducts.GetProducts(addressFrom, org);
                    office.AddProducts(products);
                }

                context.Offices.Add(office);
                context.SaveChanges();

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().AddNewOfficeCallback(true);
            }
        }

        public void DeleteOffice(int id, string org, string address)
        {
            ServerUser user = new ServerUser();
            if (user.FindUser(users, id))
            {
                if(user.Worker.Organization == org)
                {
                    context.Offices.Remove(context.Offices.GetOffice(org, address)); ;
                    context.SaveChanges();
                    user.operationContext.GetCallbackChannel<IWCFServiceCallback>().DeleteOfficeCallback(true);

                    return;
                }

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().DeleteOfficeCallback(false);
            }
        }
    }
}
