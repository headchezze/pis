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
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if(user != null)
            {
                users.Remove(user);
            }
        }

        public void FindOrgs(int id, FindOfficeFlag flag, string orgName = "", string orgType = "")
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                Dictionary<FindOfficeFlag,FindOfficesDelegate> methods = new Dictionary<FindOfficeFlag, FindOfficesDelegate>()
                {
                    { FindOfficeFlag.Main, user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindOrgsToMainCallback },
                    { FindOfficeFlag.AddressAdd, user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindOrgsToAddressAddCallback }
                };

                IQueryable<Offices> offices = null;
                if (orgName == "" && orgType == "")
                {
                    offices = context.Offices;
                }
                else
                {
                    offices = orgName != "" ? context.Offices.Where(i => i.Orgs.OrgName == orgName) : offices;
                    offices = orgType != "" ? context.Offices.Where(i => i.Orgs.Type == orgType) : offices;
                }
                List<OfficeRepresent> list = new List<OfficeRepresent>();

                foreach (Offices office in offices)
                {
                    Console.WriteLine(office.OrgName + " " + office.Adress + office.Orgs.Type + "\n");
                    list.Add(new OfficeRepresent(office.Adress, office.OrgName, office.Orgs.Type));
                }

                methods[flag]?.Invoke(list);

            }
        }

        public void FindProductsByOffice(int id, string orgName, string officeLocation)
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                var products = context.OfficeProducts.Where(i => i.Offices.Adress == officeLocation && i.Offices.OrgName == orgName);
                List<OfficeProductsRepresent> officeProducts = new List<OfficeProductsRepresent>();
                foreach (OfficeProducts product in products)
                {
                    officeProducts.Add(new OfficeProductsRepresent(product.Product, product.Cost, product.CountProduct));
                }

                OfficeRepresent office = new OfficeRepresent(officeLocation, orgName, officeProducts);

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindProductsByOfficeCallback(office);
            }
        }

        public void GetOrgsAndTypes(int id)
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
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
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                IQueryable<Workers> workers = context.Workers.Where(i => i.Login == login && i.Password == password);

                if(workers.Count() > 0)
                {
                    user.Login(new WorkerPresent(workers.First().FullName, workers.First().Org, workers.First().Login, workers.First().Password));
                    user.operationContext.GetCallbackChannel<IWCFServiceCallback>().LoginCallback(user.Worker.Fullname, user.Worker.Organization);
                    return;
                }

                    user.operationContext.GetCallbackChannel<IWCFServiceCallback>().LoginCallback(String.Empty, String.Empty);
            }
        }

        public void AddNewOffice(int id, string org, string addressTo, string adressFrom = "")
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                Offices office = new Offices()
                {
                    OrgName = org,
                    Adress = addressTo
                };

                if (adressFrom != "")
                {
                    IQueryable<OfficeProducts> products = context.OfficeProducts.Where(i => i.Offices.Adress == adressFrom);
                    foreach (OfficeProducts product in products)
                    {
                        OfficeProducts newProduct = new OfficeProducts()
                        {
                            Cost = product.Cost,
                            CountProduct = product.CountProduct,
                            Product = product.Product,
                            Office = office.IdOffice
                        };

                        office.OfficeProducts.Add(newProduct);
                    }
                }

                context.Offices.Add(office);
                context.SaveChanges();

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().AddNewOfficeCallback(true);
            }
        }

        public void DeleteOffice(int id, string org, string address)
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                if(user.Worker.Organization == org)
                {
                    context.Offices.Remove(context.Offices.Where(i => i.Adress == address && i.OrgName == org).First());
                    context.SaveChanges();
                    user.operationContext.GetCallbackChannel<IWCFServiceCallback>().DeleteOfficeCallback(true);

                    return;
                }

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().DeleteOfficeCallback(false);
            }
        }
    }
}
