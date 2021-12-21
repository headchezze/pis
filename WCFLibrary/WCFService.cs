using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WCFService" в коде и файле конфигурации.
    public class WCFService : IWCFService
    {
        public void AddProductToOffice(ICollection<OfficeProductsRepresent> officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public int Connect()
        {
            throw new NotImplementedException();
        }

        public void CreateNewOffice(OfficeRepresent officeRepresent, OfficeRepresent to = null)
        {
            throw new NotImplementedException();
        }

        public void CreateNewProduct(ProductRepresent productRepresent)
        {
            throw new NotImplementedException();
        }

        public void DeleteOffice(OfficeRepresent officeRepresent)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductFromOffice(OfficeProductsRepresent officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public int Disconnect(int id)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public ICollection<OfficeRepresent> FindOrgs(string orgName = "", string orgType = "")
        {
            throw new NotImplementedException();
        }

        public ICollection<OfficeProductsRepresent> FindProductsByOffice(string orgName, string officeLocation)
        {
            throw new NotImplementedException();
        }
    }
}
