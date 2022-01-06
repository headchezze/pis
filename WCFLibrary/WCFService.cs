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

        public void FindOrgs(int id, string orgName = "", string orgType = "")
        {
            ServerUser user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                IQueryable<Offices> offices = null;
                offices = orgName != "" ? context.Offices.Where(i => i.Orgs.OrgName == orgName) : offices;
                offices = orgType != "" ? context.Offices.Where(i => i.Orgs.Type == orgType) : offices;
                List<OfficeRepresent> list = new List<OfficeRepresent>();

                foreach (Offices office in offices)
                {
                    Console.WriteLine(office.OrgName + " " + office.Adress + office.Orgs.Type + "\n");
                    list.Add(new OfficeRepresent(office.OrgName, office.Adress, office.Orgs.Type));
                }

                user.operationContext.GetCallbackChannel<IWCFServiceCallback>().FindOrgsCallback(list);

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

    }
}
